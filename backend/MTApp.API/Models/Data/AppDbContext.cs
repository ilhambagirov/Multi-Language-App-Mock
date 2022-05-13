using Microsoft.EntityFrameworkCore;
using MTApp.API.Models.Entities;

namespace MTApp.API.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<NewsLanguage> NewsLanguages { get; set; }
        public DbSet<News> News { get; set; }
    }
}
