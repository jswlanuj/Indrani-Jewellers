using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stateId { get; set; }

        [Required(ErrorMessage = "State name is required")]
        [StringLength(45)]
        [Display(Name = "State Name")]
        public string stateName { get; set; }

        [ForeignKey("Country")]
        public int countryId { get; set; }
        //public Country Country { get; set; }
    }
}
