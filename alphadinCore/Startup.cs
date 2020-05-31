using System;
using System.Text;
using System.Threading.Tasks;
using alphadinCore.Common.Helper;
using alphadinCore.Services.Helper;
using Authentication.Services;
using Authentication.Services.Interface;
using Database.Config;
using FormEngine.Database.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace alphadinCore
{
    public class Ioc
    {
        public static void Config(IServiceCollection services)
        {
            /* Form Engine */
            FormEngine.DatabaseValidation.IOC.Di.Config(services);
            FormEngine.Services.IOC.Di.Config(services);

            /* Main Application */
            DatabaseValidation.IOC.Di.Config(services);
            Repository.Services.IOC.Di.Config(services);
            
            services.AddTransient<AuthHelper>();
            services.AddTransient<SmsHelper>();
            services.AddTransient<IOnlineUserService, OnlineUserService>();
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string MyAllowSpecificOrigins = "_AlphadinAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextModel>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DBCoreConnection"));
            });

            services.AddDbContext<FormEngineDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("FormEngineDbConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    };
                });


            services.AddMvc();

            Ioc.Config(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(builder =>
            //    builder.WithOrigins("http://localhost:8080"));

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            FirstData.Initialize(app);
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DbContextModel>())
                {
                    context.Database.Migrate();
                }
            }

            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FormEngineDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
