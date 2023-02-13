using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteVitrineEbeniste.Models
{
    public class UserArticle
    {
        public int UserId { get; set; } 
        public User Viewer { get; set; }
        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
