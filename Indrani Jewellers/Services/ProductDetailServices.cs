using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Indrani_Jewellers.Services
{
    public class ProductDetailServices
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ProductDetailViewModel> GetProductDetails()
        {
            try
            {
                var employeeMaster = _context.ProductDetailViewModels.FromSqlRaw("CALL getProductDetails").ToList();

                if (employeeMaster == null || employeeMaster.Count == 0)
                {
                    return new List<ProductDetailViewModel>();
                }
                else
                {
                    return employeeMaster;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<ProductDetailViewModel>();
            }
        }

        public int InsertProductDetails(List<ProductDetailsModel> productDetails)
        {
            int status = 0;
            try
            {
                foreach (var pd in productDetails)
                {
                    var parameter = new List<MySqlParameter>();

                    parameter.Add(new MySqlParameter("@p_fk_pm_id", pd.fk_pm_id));
                    parameter.Add(new MySqlParameter("@p_HUID", pd.HUID));
                    parameter.Add(new MySqlParameter("@p_weight", pd.weight));
                    parameter.Add(new MySqlParameter("@p_createdBy", pd.createdBy));

                    var query = "CALL InsertProductDetails(@p_fk_pm_id, @p_HUID, @p_weight, @p_createdBy)";

                    status = _context.Database.ExecuteSqlRaw(query, parameter.ToArray());
                }

                return status;
            }
            catch
            {
                return -1;
            }
        }


    }
}
