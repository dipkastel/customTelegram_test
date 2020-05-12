using FormEngine.Database.Models;
using FormEngine.Database.Models.Quiz;
using Microsoft.EntityFrameworkCore;

namespace FormEngine.Database.Config
{
    public class FormEngineDbContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }

        /* Quiz */
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionType> OptionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SubQuestion> SubQuestions { get; set; }

    }
}