using System.Linq;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Config
{
    public class DbContextModel : DbContext
    {
        public DbContextModel(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            base.OnModelCreating(builder);
        }

        public DbSet<Const> Consts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens{ get; set; }
        public DbSet<Sms> Sms { get; set; }
        public DbSet<TesterProfile> TesterProfiles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserEducation> Educations { get; set; }
        public DbSet<UserJob> Jobs { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<FavoriteTag> FavoriteTags { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<SchoolQuisQuestionOption> SchoolQuisQuestionOptions { get; set; }
        public DbSet<SchoolUnit> SchoolUnits { get; set; }
        public DbSet<SchoolQuizQuestion> SchoolQuizQuestions { get; set; }
        public DbSet<SchoolQuizCourse> SchoolQuizCourses { get; set; }
        public DbSet<SchoolCourse> SchoolCourses { get; set; }
        public DbSet<SchoolTopic> SchoolTopics { get; set; }
        public DbSet<UserSocials> UserSocials { get; set; }
        public DbSet<GeneralTypes> GeneralTypes { get; set; }
        public DbSet<SchoolCourseCertificate> SchoolCourseCertificates { get; set; }
    }
}
