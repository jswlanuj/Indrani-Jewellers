using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class GenerateInvoice
    {
        [Key]
        public int Id { get; set; }

        public string? GoldRate { get; set; }
        public string? GoldMakingCharges { get; set; }
        public string? SilverRate { get; set; }
        public string? SilverMakingCharges { get; set; }

        public string? InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public float? TotalPrice { get; set; }
        public int? Gst { get; set; }
        public float? NetPrice { get; set; }

        public List<InvoiceItemList> invoiceItemLists { get; set; }

    }
}
