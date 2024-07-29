using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indrani_Jewellers.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        [DisplayName("User ID")]
        public int? userId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        [StringLength(45, ErrorMessage = "Username must be between 1 and 45 characters", MinimumLength = 1)]
        public string? userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [StringLength(45, ErrorMessage = "Password must be between 1 and 45 characters", MinimumLength = 1)]
        public string? password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DisplayName("Confirm Password")]
        [StringLength(45, ErrorMessage = "Confirm Password must be between 1 and 45 characters", MinimumLength = 1)]
        public string? ConfirmPassword { get; set; }


        [DisplayName("Active Status")]
        public int? isActive { get; set; }

        [DisplayName("Is Archived")]
        public int? isarchived { get; set; }

        [DisplayName("Role")]
        public int? roleId { get; set; }

        [NotMapped]
        [DisplayName("Role")]
        public string? role { get; set; }

        [DisplayName("Created By")]
        public int? createdBy { get; set; }

        [DisplayName("Created Date")]
        public DateTime? createdOn { get; set; }

        [DisplayName("Modified By")]
        public int? modifiedBy { get; set; }

        [DisplayName("Modified On")]
        public DateTime? modifiedOn { get; set; }

        public int? isFirstLogin { get; set; }

        public int? loginAttempts { get; set; }

        public string? DisplayName { get; set; }

    }
}
