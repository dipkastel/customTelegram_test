using System;
using System.Text;
using System.Threading.Tasks;
using alphadinCore.Common.Helper;
using alphadinCore.Services.Helper;
using Authentication.Services;
using Authentication.Services.Interface;
using Database.Config;
using DatabaseValidation.Operator;
using DatabaseValidation.Operator.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Operator.Interfaces;
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
using Services.Operator;
using Services.Operator.Authentication;
using Services.Operator.Authentication.Interfaces;
using Services.Operator.Interfaces;
using Services.Repository;

namespace alphadinCore
{
    public class Ioc
    {
        public static void Config(IServiceCollection services)
        {
            #region Repository

            services.AddTransient<IActionService, ActionService>();
            services.AddTransient<IRoleActionService, RoleActionService>();
            services.AddTransient<IUserActionService, UserActionService>();
            services.AddTransient<IRoleAccessService, RoleAccessService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IConstService, ConstService>();
            services.AddTransient<IFavoriteTagService, FavoriteTagService>();
            services.AddTransient<IGeneralTypesService, GeneralTypesService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ISchoolCourseService, SchoolCourseService>();
            services.AddTransient<ISchoolQuisQuestionOptionService, SchoolQuisQuestionOptionService>();
            services.AddTransient<ISchoolQuizCourseService, SchoolQuizCourseService>();
            services.AddTransient<ISchoolQuizQuestionService, SchoolQuizQuestionService>();
            services.AddTransient<ISchoolTopicService, SchoolTopicService>();
            services.AddTransient<ISchoolUnitService, SchoolUnitService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<ITesterProfileService, TesterProfileService>();
            services.AddTransient<IUserEducationService, UserEducationService>();
            services.AddTransient<IUserJobService, UserJobService>();
            services.AddTransient<IUserLanguageService, UserLanguageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserSocialsService, UserSocialsService>();
            services.AddTransient<IUserTokenService, UserTokenService>();
            services.AddTransient<ISchoolCourseCertificateService, SchoolCourseCertificateService>();




            #endregion

            #region Validation

            services.AddTransient<IActionValidation, ActionValidation>();
            services.AddTransient<IRoleActionValidation, RoleActionValidation>();
            services.AddTransient<IUserActionValidation, UserActionValidation>();
            services.AddTransient<IRoleAccessValidation, RoleAccessValidation>();
            services.AddTransient<IRoleValidation, RoleValidation>();

            services.AddTransient<IConstValidation, ConstValidation>();
            services.AddTransient<IFavoriteTagValidation, FavoriteTagValidation>();
            services.AddTransient<IGeneralTypesValidation, GeneralTypesValidation>();
            services.AddTransient<ILanguageValidation, LanguageValidation>();
            services.AddTransient<ILocationValidation, LocationValidation>();
            services.AddTransient<ISchoolCourseValidation, SchoolCourseValidation>();
            services.AddTransient<ISchoolQuisQuestionOptionValidation, SchoolQuisQuestionOptionValidation>();
            services.AddTransient<ISchoolQuizCourseValidation, SchoolQuizCourseValidation>();
            services.AddTransient<ISchoolQuizQuestionValidation, SchoolQuizQuestionValidation>();
            services.AddTransient<ISchoolTopicValidation, SchoolTopicValidation>();
            services.AddTransient<ISchoolUnitValidation, SchoolUnitValidation>();
            services.AddTransient<ISmsValidation, SmsValidation>();
            services.AddTransient<ITesterProfileValidation, TesterProfileValidation>();
            services.AddTransient<IUserEducationValidation, UserEducationValidation>();
            services.AddTransient<IUserJobValidation, UserJobValidation>();
            services.AddTransient<IUserLanguageValidation, UserLanguageValidation>();
            services.AddTransient<IUserValidation, UserValidation>();
            services.AddTransient<IUserSocialsValidation, UserSocialsValidation>();
            services.AddTransient<IUserTokenValidation, UserTokenValidation>();
            services.AddTransient<ISchoolCourseCertificateValidation, SchoolCourseCertificateValidation>();

            #endregion

            services.AddTransient<AuthHelper>();
            services.AddTransient<SmsHelper>();

            services.AddSingleton<IOnlineUserService, OnlineUserService>();

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
    }
}
