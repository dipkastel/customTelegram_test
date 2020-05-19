using FormEngine.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FormEngine.Database.Config
{
    public class FormEngineDbContext : DbContext
    {
        public FormEngineDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementAttribute> ElementAttributes { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<HtmlAttribute> HtmlAttributes { get; set; }
        public DbSet<HtmlTag> HtmlTags { get; set; }

    }
}