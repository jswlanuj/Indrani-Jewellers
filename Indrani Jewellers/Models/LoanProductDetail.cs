using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{

    public class LoanProductDetail
    {
        [Key]
        [DisplayName("LPDI")]
        public int LPDI { get; set; }

        [DisplayName("LID")]
        public int LID { get; set; }

        [DisplayName("CID")]
        public int CID { get; set; }

        [DisplayName("Metal")]
        [StringLength(45)]
        public string Metal { get; set; }

        [DisplayName("Product Name")]
        [StringLength(45)]
        public string ProductName { get; set; }

        [DisplayName("Product Weight")]
        [StringLength(45)]
        public string ProductWeight { get; set; }

        [DisplayName("Is Active")]
        public int IsActive { get; set; }

        [DisplayName("Is Archived")]
        public int IsArchived { get; set; }

        [DisplayName("Created By")]
        public int CreatedBy { get; set; }

        [DisplayName("Created On")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        [DisplayName("Modified On")]
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
