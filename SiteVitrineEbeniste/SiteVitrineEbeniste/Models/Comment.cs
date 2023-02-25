using System.ComponentModel.DataAnnotations;

namespace SiteVitrineEbeniste.Models
{
    public class Comment
    {
        public int CommenterId { get; set; }
        public User Commenter { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        [Required]
        public string Comments  { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }

    }
}
