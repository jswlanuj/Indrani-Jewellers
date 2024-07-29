using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class ProductDetailViewModel
    {
        [Key]
        public int? pdId { get; set; }

        public int? HUID { get; set; }

        [DisplayName("Weight")]
        public string? weight { get; set; }

        [DisplayName("Product")]
        public string? productName { get; set; }
    }
}
