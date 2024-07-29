using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int roleId { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [StringLength(45)]
        [Display(Name = "Role")]
        public string role { get; set; }
    }
}
