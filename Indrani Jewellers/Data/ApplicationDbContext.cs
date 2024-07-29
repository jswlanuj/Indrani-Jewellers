using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;

namespace Indrani_Jewellers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<ProductMasterModel> product_master { get; set; }
        public virtual DbSet<GenerateInvoice> generateInvoice { get; set; }

        public virtual DbSet<ProductMasterModel> ProductMasterModels { get; set; }
        public virtual DbSet<EmployeeModel> EmployeeModels { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserViewModel> userViewModels { get; set; }

        public virtual DbSet<ProductDetailsModel> ProductDetailsModels { get; set; }

        public virtual DbSet<ProductDetailViewModel> ProductDetailViewModels { get; set; }

        public virtual DbSet<Customer> customer_master { get; set; }

        //public virtual DbSet<Customer> customer_master { get; set; }


        public virtual DbSet<Users> users { get; set; }

        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanProductDetail> loanProductDetail { get; set; }
    }
}
