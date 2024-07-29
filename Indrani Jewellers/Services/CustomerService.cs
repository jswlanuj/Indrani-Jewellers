using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Indrani_Jewellers.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public List<Customer> GetAllCustomerList()
        {
            try
            {
                var customer = _context.customer_master.FromSqlRaw("CALL getAllCustomerList").ToList();

                if (customer == null || customer.Count == 0)
                {
                    return new List<Customer>();
                }
                else
                {
                    return customer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occoured" +  ex.Message);
                return new List<Customer>();
            }
        }

        public int InsertCustomer(Customer c, string customerCode,int userId)
        {
            int status;
            try
            {
                var parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("@p_CustomerName", c.CustomerName));
                parameters.Add(new MySqlParameter("@p_CustomerID", customerCode));
                parameters.Add(new MySqlParameter("@p_Email", c.Email));
                parameters.Add(new MySqlParameter("@p_Contact", c.Contact));
                parameters.Add(new MySqlParameter("@p_DateOfBirth", c.DateOfBirth));
                parameters.Add(new MySqlParameter("@p_CreatedBy", userId));

                var query = "Call InsertCustomer(@p_CustomerName,@p_CustomerID,@p_Email,@p_Contact,@p_DateOfBirth,@p_CreatedBy)";

                status = _context.Database.ExecuteSqlRaw(query, parameters.ToArray());

                return status;
            }
            catch
            {
                return -1;
            }
        }

    }
}
