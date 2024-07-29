using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class Loan
    {
        [Key]
        public int? LID { get; set; }


        [StringLength(45)]
        public string? CID { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }


        [StringLength(45)]
        [Display(Name = "Customer ID")]
        public string? CustomerID { get; set; }

        [StringLength(45)]
        public string? Contact { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


        [StringLength(45)]
        [Display(Name = "Product Name")]
        public string? Metal { get; set; }


        [Display(Name = "Total Gold Weight")]
        public string? TotalGoldWeight { get; set; }



        [Display(Name = "Total Silver Weight")]
        public decimal? TotalSilverWeight { get; set; }


        [StringLength(45)]
        [Display(Name = "Gold Rate")]
        public string? GoldRate { get; set; }

        [StringLength(45)]
        [Display(Name = "Silver Rate")]
        public string? SilverRate { get; set; }


        [StringLength(45)]
        [Display(Name = "Loan Amount")]
        public string? LoanAmount { get; set; }


        [Display(Name = "From Date")]
        [DataType(DataType.DateTime)]
        public DateTime? FromDate { get; set; }


        [Display(Name = "To Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ToDate { get; set; }


        [StringLength(45)]
        [Display(Name = "Interest Per Annum")]
        public string IntrestPerMonth { get; set; }


        [StringLength(45)]
        [Display(Name = "Total Duration")]
        public string? TotalDuration { get; set; }

        [StringLength(45)]
        [Display(Name = "Is Active")]
        public int? IsActive { get; set; }


        [StringLength(45)]
        [Display(Name = "Is Archived")]
        public int? IsArchived { get; set; }


        [StringLength(45)]
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }


        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }


        [Display(Name = "Modified By")]
        public int? ModifiedBy { get; set; }


        [Display(Name = "Modified On")]
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }


        [StringLength(45)]
        [Display(Name = "Amount Given")]
        public string? AmountGiven { get; set; }


        [StringLength(45)]
        [Display(Name = "Amount Taken")]
        public string? AmountTaken { get; set; }


        [Display(Name = "Loan Date")]
        [DataType(DataType.DateTime)]
        public DateTime? LoanDate { get; set; }

        [Display(Name = "Loan Completed Date")]
        [DataType(DataType.DateTime)]
        public DateTime? LoanCompletedDate { get; set; }

        [ValidateNever]
        public List<LoanProductDetail> loanProductDetails { get; set; }
    }
}
