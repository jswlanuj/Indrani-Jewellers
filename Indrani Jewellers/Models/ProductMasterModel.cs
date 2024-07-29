using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indrani_Jewellers.Models
{

    [Table("product_master")]
    public class ProductMasterModel
    {
        [Key]
        public int productId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [DisplayName("Product Name")]
        public string? productName { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [DisplayName("Quantity")]
        public int? quantity { get; set; }


        [Required(ErrorMessage = "Grams is required")]
        [DisplayName("Grams")]
        public int? gms { get; set; }

        public string? ImageUrl { get; set; }




    }
}
