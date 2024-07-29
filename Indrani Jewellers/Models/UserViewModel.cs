using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Indrani_Jewellers.Models
{
    public class UserViewModel
    {
        [Key]
        public int userId { get; set; }

        [DisplayName("Active Status")]
        public int isActive { get; set; }

        [DisplayName("User Name")]
        public string userName { get; set; }

        [DisplayName("Role")]
        public string role { get; set; }
    }
}
