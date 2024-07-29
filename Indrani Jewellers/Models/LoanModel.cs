using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Indrani_Jewellers.Models
{
    [Keyless]
    public class LoanModel
    {
      
        [DisplayName("Customer Identity Number")]
        public string CID { get; set; }
    }
}
