using System;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class EmployeeModel
    {
        [Key]
        public int empId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Employee Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Employee code is required")]
        [Display(Name = "Employee Code")]
        public string employeeCode { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid contact number")]
        [Display(Name = "Contact")]
        public string contact { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [Display(Name = "Location")]
        public string location { get; set; }

        // Nullable properties
        [Display(Name = "Country")]
        public int? country { get; set; }

        [Display(Name = "State")]
        public int? state { get; set; }

        [Display(Name = "City")]
        public int? city { get; set; }

        [Display(Name = "Role")]
        public int? role { get; set; }

        [Display(Name = "Created By")]
        public int? createdBy { get; set; }

        [Display(Name = "Created On")]
        public DateTime? createdOn { get; set; }

        [Display(Name = "Modified By")]
        public int? modifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? modifiedOn { get; set; }

        [Display(Name = "Is Archived")]
        public int? isArchived { get; set; }

        [Display(Name = "Is Active")]
        public int? isActive { get; set; }
    }
}
