using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Import namespace for Table attribute

namespace Indrani_Jewellers.Models
{
    [Table("product_details")] // Specify the actual table name here
    public class ProductDetailsModel
    {
        [Key]
        public int? pdId { get; set; }

        [DisplayName("Product")]
        public int? fk_pm_id { get; set; }

        public string? productName { get; set; }

        [Required(ErrorMessage = "HUID is required")]
        [DisplayName("HUID")]
        public string? HUID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [DisplayName("Quantity")]
        public int? qty { get; set; }

        [DisplayName("Weight")]
        public string? weight { get; set; }

        public int? createdBy { get; set; }

        public DateTime? createdOn { get; set; }

        public int? modifiedBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public int? isArchived { get; set; }
    }
}

