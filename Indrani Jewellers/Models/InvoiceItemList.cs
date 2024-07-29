using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class InvoiceItemList
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? HUID { get; set; }

        public float? Carat { get; set; }
        public float? Weight { get; set; }
        public float? Price { get; set; }
    }
}
