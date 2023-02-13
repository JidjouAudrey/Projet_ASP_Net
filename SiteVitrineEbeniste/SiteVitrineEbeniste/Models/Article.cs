using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SiteVitrineEbeniste.Datas.Enum;
using SiteVitrineEbeniste.Datas.Enums;

namespace SiteVitrineEbeniste.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Material Material { get; set; }
        [Required]  
        public string Description { get; set; }
        [Required]
        public string UrlImage { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }

        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public User Admin { get; set; }

        public List<UserArticle> UserArticles { get; set; }

    }
}
