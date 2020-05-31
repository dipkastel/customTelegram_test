using Microsoft.Extensions.DependencyInjection;
using Services.Operator;
using Services.Operator.Authentication;
using Services.Operator.Authentication.Interfaces;
using Services.Operator.Interfaces;
using Services.Operator.Queue;
using Services.Operator.Queue.Interface;
using Services.Operator.School;
using Services.Operator.School.Interfaces;

// ReSharper disable once CheckNamespace
namespace Repository.Services.IOC
{
    public class Di
    {
        public static void Config(IServiceCollection services)
        {
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
            services.AddTransient<ISchoolUserUnitReadService, SchoolUserUnitReadService>();

            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<ITesterProfileService, TesterProfileService>();
            services.AddTransient<IUserEducationService, UserEducationService>();
            services.AddTransient<IUserJobService, UserJobService>();
            services.AddTransient<IUserFavoriteService, UserFavoriteService>();

            services.AddTransient<IUserLanguageService, UserLanguageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserSocialsService, UserSocialsService>();
            services.AddTransient<IUserTokenService, UserTokenService>();
            services.AddTransient<ISchoolCourseCertificateService, SchoolCourseCertificateService>();


            services.AddTransient<IQueueService, QueueService>();
        }
    }
}