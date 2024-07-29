using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cityId { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [StringLength(45)]
        [Display(Name = "City Name")]
        public string cityName { get; set; }

        [ForeignKey("State")]
        public int stateId { get; set; }
       // public State State { get; set; }
    }
}
