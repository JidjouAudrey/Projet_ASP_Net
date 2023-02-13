using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteVitrineEbeniste.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name{ get; set; }
        [Required]
        public string  Surname{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string  Biography { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CountryId")]
        public City City { get; set; }

        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }

        public List<Article> PublishedArticles { get; set; }

        public List<UserArticle> UserArticles { get; set; }
    }
}
