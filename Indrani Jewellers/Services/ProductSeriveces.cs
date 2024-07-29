using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Indrani_Jewellers.Services
{
    public class ProductSeriveces
    {
        private readonly ApplicationDbContext _context;

        public ProductSeriveces(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductMasterModel> GetProductMasterList()
        {
            try
            {
                var productMasters = _context.ProductMasterModels.FromSqlRaw("CALL getProductMasterData").ToList();

                if (productMasters == null || productMasters.Count == 0)
                {
                    return new List<ProductMasterModel>();
                }
                else
                {
                    return productMasters;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<ProductMasterModel>();
            }
        }


        public int InsertProductMaster(ProductMasterModel pm)
        {
            int status;
            try
            {
                var parameter = new List<MySqlParameter>();

                parameter.Add(new MySqlParameter("@productName", pm.productName));
                parameter.Add(new MySqlParameter("@quantity", pm.quantity));
                parameter.Add(new MySqlParameter("@gms", pm.gms));
                parameter.Add(new MySqlParameter("@imageUrl", pm.ImageUrl));

                var query = "CALL insertProductMaster(@productName, @quantity, @gms,@imageUrl)";

                status = _context.Database.ExecuteSqlRaw(query, parameter.ToArray());

                return status;
            }
            catch
            {
                return -1;
            }
        }
        public IEnumerable<ProductMasterModel> GetProductMasterDataByID(int? id)
        {
            try
            {
                var parameter = new List<MySqlParameter>();
                parameter.Add(new MySqlParameter("@productId", id));

                var query = "CALL getProductMasterDataByID(@productId)";
                var productMasters = _context.ProductMasterModels.FromSqlRaw(query, parameter.ToArray()).ToList();

                return productMasters;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product master data: {ex.Message}");
                return null;
            }
        }

        public int UpdadteProductMaster(ProductMasterModel pm)
        {
            int status;
            try
            {
                var parameter = new List<MySqlParameter>();

                parameter.Add(new MySqlParameter("@productId", pm.productId));
                parameter.Add(new MySqlParameter("@productName", pm.productName));
                parameter.Add(new MySqlParameter("@quantity", pm.quantity));
                parameter.Add(new MySqlParameter("@gms", pm.gms));

                var query = "CALL updateProductMaster(@productName,@quantity,@gms,@productId)";

                status = _context.Database.ExecuteSqlRaw(query, parameter.ToArray());

                return status;
            }
            catch
            {
                return -1;
            }
        }

        public int DeleteproductMaster(int? id)
        {
            int status;
            try
            {
                var parameter = new List<MySqlParameter>();
                parameter.Add(new MySqlParameter("@productId", id));
                var query = $"CALL deleteProductMaster(@productId)";
                status = _context.Database.ExecuteSqlRaw(query, parameter.ToArray());

                return status;
            }
            catch
            {
                return -1;
            }
        }

    }
}
