
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

            modelBuilder.Entity<UserArticle>().HasOne(ua => ua.Viewer).
                WithMany(viewer => viewer.UserArticles).HasForeignKey(ua => ua.UserId);
            modelBuilder.Entity<UserArticle>().HasOne(us => us.Article).
                WithMany(article => article.UserArticles).HasForeignKey(ua => ua.ArticleId);
            modelBuilder.Entity<Message>().HasOne(message => message.Sender).
                WithMany(sender => sender.SentMessages).HasForeignKey(message => message.SenderId);
            modelBuilder.Entity<Message>().HasOne(message => message.Receiver).
                WithMany(receiver => receiver.ReceivedMessages).HasForeignKey(message => message.ReceiverId).
                OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<Comment>().HasOne(comment => comment.Commenter).
                WithMany(commenter => commenter.Comments).HasForeignKey(comment => comment.CommenterId).
                OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>().HasOne(aComment => aComment.Article).
                WithMany(article => article.Comments).HasForeignKey(aComment => aComment.ArticleId);
            modelBuilder.Entity<Comment>().HasKey(new string[] { "CommenterId", "ArticleId"});
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserArticle> UserArticles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
