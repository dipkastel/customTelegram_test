using DatabaseValidation.Operator;
using DatabaseValidation.Operator.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Operator.School;
using DatabaseValidation.Operator.School.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseValidation.IOC
{
    public class Di
    {
        public static void Config(IServiceCollection services)
        {
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
            services.AddTransient<ISchoolUserUnitReadValidation, SchoolUserUnitReadValidation>();

            services.AddTransient<ISmsValidation, SmsValidation>();
            services.AddTransient<ITesterProfileValidation, TesterProfileValidation>();
            services.AddTransient<IUserEducationValidation, UserEducationValidation>();
            services.AddTransient<IUserJobValidation, UserJobValidation>();
            services.AddTransient<IUserLanguageValidation, UserLanguageValidation>();
            services.AddTransient<IUserValidation, UserValidation>();
            services.AddTransient<IUserSocialsValidation, UserSocialsValidation>();
            services.AddTransient<IUserTokenValidation, UserTokenValidation>();
            services.AddTransient<ISchoolCourseCertificateValidation, SchoolCourseCertificateValidation>();
            services.AddTransient<IUserFavoriteValidation, UserFavoriteValidation>();

        }
    }
}