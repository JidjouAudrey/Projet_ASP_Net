using System.ComponentModel.DataAnnotations;

namespace SiteVitrineEbeniste.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameCountry { get; set; }
        [Required]
        public string CountryCode { get; set; }

        public List<City> Cities { get; set; }

    }
}
