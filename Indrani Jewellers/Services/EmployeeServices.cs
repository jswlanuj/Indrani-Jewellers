using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Indrani_Jewellers.Services
{
    public class EmployeeServices
    {
        private readonly ApplicationDbContext _context;

        public EmployeeServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<EmployeeModel> GetEmployeeData()
        {
            try
            {
                var employeeMaster = _context.EmployeeModels.FromSqlRaw("CALL getEmployeeMasterData").ToList();

                if(employeeMaster == null || employeeMaster.Count == 0)
                {
                    return new List<EmployeeModel>();
                }
                else
                {
                    return employeeMaster;
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<EmployeeModel>();
            }
        }

        public List<Country> GetCountry()
        {
            try
            {
                var country = _context.Countries.FromSqlRaw("CALL getCountry").ToList();

                if (country == null || country.Count == 0)
                {
                    return new List<Country>();
                }
                else
                {
                    return country;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<Country>();
            }
        }

        public List<State> GetState()
        {
            try
            {
                var state = _context.States.FromSqlRaw("CALL getState").ToList();

                if (state == null || state.Count == 0)
                {
                    return new List<State>();
                }
                else
                {
                    return state;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<State>();
            }
        }

        public List<City> GetCity()
        {
            try
            {
                var state = _context.Cities.FromSqlRaw("CALL getCity").ToList();

                if (state == null || state.Count == 0)
                {
                    return new List<City>();
                }
                else
                {
                    return state;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<City>();
            }
        }
        public List<Role> GetRoles()
        {
            try
            {
                var state = _context.Roles.FromSqlRaw("CALL getRoles").ToList();

                if (state == null || state.Count == 0)
                {
                    return new List<Role>();
                }
                else
                {
                    return state;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<Role>();
            }
        }

        public int InsertEmployee(EmployeeModel em, string empcode)
        {
            int status;
            try
            {
                var parameter = new List<MySqlParameter>();

                parameter.Add(new MySqlParameter("@p_name", em.name));
                parameter.Add(new MySqlParameter("@p_employeeCode", empcode));
                parameter.Add(new MySqlParameter("@p_email", em.email));
                parameter.Add(new MySqlParameter("@p_contact", em.contact));
                parameter.Add(new MySqlParameter("@p_address", em.address));
                parameter.Add(new MySqlParameter("@p_location", em.location));
                parameter.Add(new MySqlParameter("@p_country", em.country));
                parameter.Add(new MySqlParameter("@p_state", em.state));
                parameter.Add(new MySqlParameter("@p_city", em.city));
                parameter.Add(new MySqlParameter("@p_role", em.role));
                parameter.Add(new MySqlParameter("@p_createdBy", em.createdBy));
                parameter.Add(new MySqlParameter("@p_modifiedBy", em.modifiedBy));

                var query = "CALL insertEmployee(@p_name, @p_employeeCode, @p_email, @p_contact, @p_address, @p_location, @p_country, @p_state, @p_city, @p_role, @p_createdBy, @p_modifiedBy)";

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
