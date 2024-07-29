using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace Indrani_Jewellers.Services
{
    public class LoanService
    {
        private readonly ApplicationDbContext _context;
        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Loan> GetLoanList()
        {
            try
            {
                var loan = _context.Loans.FromSqlRaw("CALL getLoanDetails").ToList();

                if (loan == null || loan.Count == 0)
                {
                    return new List<Loan>();
                }
                else
                {
                    return loan;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occoured" + ex.Message);
                return new List<Loan>();
            }
        }

        public int InsertLoan(Loan loan)
        {
            int lastInsertId = -1;
            try
            {
                var parameters = new[]
                {
            new MySqlParameter("@p_CID", loan.CID),
            new MySqlParameter("@p_CustomerName", loan.CustomerName),
            new MySqlParameter("@p_CustomerID", loan.CustomerID),
            new MySqlParameter("@p_Contact", loan.Contact),
            new MySqlParameter("@p_Email", loan.Email),
            new MySqlParameter("@p_GoldRate", loan.GoldRate),
            new MySqlParameter("@p_SilverRate", loan.SilverRate),
            new MySqlParameter("@p_LoanAmount", loan.LoanAmount),
            new MySqlParameter("@p_FromDate", loan.FromDate),
            new MySqlParameter("@p_ToDate", loan.ToDate),
            new MySqlParameter("@p_IntrestPerAnnum", loan.IntrestPerMonth), // Assuming 'IntrestPerAnnum' matches the actual column name in your database
            new MySqlParameter("@p_TotalDuration", loan.TotalDuration),
            new MySqlParameter("@p_CreatedBy", loan.CreatedBy),
            new MySqlParameter("@p_AmountGiven", loan.AmountGiven),
            new MySqlParameter("@p_AmountTaken", loan.AmountTaken),
            new MySqlParameter("@p_LoanDate", loan.LoanDate),
            new MySqlParameter("@p_LoanCompletedDate", loan.LoanCompletedDate),
            new MySqlParameter("@p_LastInsertID", MySqlDbType.Int32) { Direction = ParameterDirection.Output }
        };

                var query = "CALL InsertLoanDetails(" +
                            "@p_CID, @p_CustomerName, @p_CustomerID, @p_Contact, @p_Email, " +
                            "@p_GoldRate, @p_SilverRate, @p_LoanAmount, @p_FromDate, @p_ToDate, " +
                            "@p_IntrestPerAnnum, @p_TotalDuration, @p_CreatedBy, @p_AmountGiven, " +
                            "@p_AmountTaken, @p_LoanDate, @p_LoanCompletedDate, @p_LastInsertID)";

                _context.Database.ExecuteSqlRaw(query, parameters);

                lastInsertId = Convert.ToInt32(parameters.First(p => p.ParameterName == "@p_LastInsertID").Value);

                return lastInsertId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1;
            }
        }




        public int InsertLoanProducts(LoanProductDetail product, int lid)
        {
            try
            {
                var parameters = new List<MySqlParameter>
        {
            new MySqlParameter("@p_LID", lid),
            new MySqlParameter("@p_Metal", product.Metal),
            new MySqlParameter("@p_ProductName", product.ProductName),
            new MySqlParameter("@p_ProductWeight", product.ProductWeight),
            new MySqlParameter("@p_CreatedBy", product.CreatedBy),
            new MySqlParameter("@p_CreatedOn", product.CreatedOn)
        };

                var query = "CALL InsertLoanProductDetails(" +
                            "@p_LID, @p_Metal, @p_ProductName, @p_ProductWeight, @p_CreatedBy, @p_CreatedOn)";

                _context.Database.ExecuteSqlRaw(query, parameters.ToArray());

                return 1; // Success
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1;
            }
        }

        public List<LoanProductDetail> GetLoanProductList(int? id)
        {
            try
            {
                var parameter = new List<MySqlParameter>();
                parameter.Add(new MySqlParameter("@p_id", id));

                var query = "CALL sp_getLoanProducts(@p_id)";
                var productMasters = _context.loanProductDetail.FromSqlRaw(query, parameter.ToArray()).ToList();
                return productMasters;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occoured" + ex.Message);
                return new List<LoanProductDetail>();
            }
        }




    }
}


