using alphadinCore.Model;
using alphadinCore.Model.dbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.data
{
    public class dbContextModel : DbContext
    {
        public dbContextModel(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);
        }

        public DbSet<ConstModel> Consts { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<RoleAccessModel> RoleAccess { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserTokenModel> UserTokens{ get; set; }
        public DbSet<SmsModel> Sms { get; set; }
        public DbSet<TesterProfileModel> TesterProfiles { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
        public DbSet<UserEducationModel> Educations { get; set; }
        public DbSet<UserJobModel> Jobs { get; set; }
        public DbSet<UserLanguageModel> UserLanguages { get; set; }
        public DbSet<FavoriteTagModel> FavoriteTags { get; set; }
        public DbSet<UserFavoriteModel> UserFavorites { get; set; }
        public DbSet<SchoolQuisQuestionOptionModel> SchoolQuisQuestionOptions { get; set; }
        public DbSet<SchoolUnitModel> SchoolUnits { get; set; }
        public DbSet<SchoolQuizQuestionModel> SchoolQuizQuestions { get; set; }
        public DbSet<SchoolQuizCourseModel> SchoolQuizCourses { get; set; }
        public DbSet<SchoolCourseModel> SchoolCourses { get; set; }
        public DbSet<SchoolTopicModel> SchoolTopics { get; set; }
        public DbSet<UserSocialsModel> UserSocials { get; set; }
        public DbSet<GeneralTypesModel> GeneralTypes { get; set; }
    }
}
