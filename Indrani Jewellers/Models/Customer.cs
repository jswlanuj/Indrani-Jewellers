using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [Display(Name = "Customer ID")]
        public int CID { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [MaxLength(45)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MaxLength(45)]
        [Display(Name = "Contact Number")]
        public string Contact { get; set; }


        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Active Status")]
        public int? IsActive { get; set; }

        [Display(Name = "Is Archived")]
        public int? IsArchived { get; set; }

        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public int? ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}
