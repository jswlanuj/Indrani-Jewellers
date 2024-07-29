using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int countryId { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [StringLength(45)]
        [Display(Name = "Country Name")]
        public string countryName { get; set; }
    }
}
