using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteVitrineEbeniste.Models
{
    public class Message
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string Containt { get; set; }
        [Required]
        public DateTime SentDate { get; set; }
        
        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

    }
}
