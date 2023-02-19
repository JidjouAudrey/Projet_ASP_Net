using Microsoft.EntityFrameworkCore;
using SiteVitrineEbeniste.Models;

namespace SiteVitrineEbeniste.Datas
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserArticle>().HasKey(us => new
            {
                us.UserId,
                us.ArticleId
            });

            modelBuilder.Entity<UserArticle>().HasOne(us => us.Viewer).
                WithMany(viewer => viewer.UserArticles).HasForeignKey(viewer => viewer.UserId);
            modelBuilder.Entity<UserArticle>().HasOne(us => us.Article).
                WithMany(article => article.UserArticles).HasForeignKey(article => article.ArticleId);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<UserArticle> UserArticles { get; set; }
    }
}
