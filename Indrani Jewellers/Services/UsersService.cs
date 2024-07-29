using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Indrani_Jewellers.Services
{
    public class LoginResult
    {
        public List<Users> Users { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class UsersService
    {
        private readonly ApplicationDbContext _context;

        public UsersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public LoginResult GetUsernamePassword(string username, string password)
        {
            try
            {
                var parameter = new List<MySqlParameter>();

                parameter.Add(new MySqlParameter("@u_username", username));
                parameter.Add(new MySqlParameter("@u_password", password));

                var user = _context.users.FromSqlRaw("CALL authenticateUsers(@u_username, @u_password)", parameter.ToArray()).ToList();

                if (user == null || user.Count == 0)
                {
                    return new LoginResult { Users = new List<Users>(), ErrorMessage = "Invalid username or password." };
                }
                else
                {
                    if (user[0].isActive == 1)
                    {
                        return new LoginResult { Users = new List<Users>(), ErrorMessage = "Account locked. Please try again later." };
                    }
                    else
                    {
                        return new LoginResult { Users = user, ErrorMessage = null };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new LoginResult { Users = new List<Users>(), ErrorMessage = "An error occurred during login." };
            }
        }

        public List<Role> GetRoles(int? roleId)
        {
            try
            {
                var parameter = new List<MySqlParameter>();
                parameter.Add(new MySqlParameter("@p_roleid", roleId));
                var query = "CALL getRole(@p_roleid)";
                var roles = _context.Roles.FromSqlRaw(query, parameter.ToArray()).ToList();
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product master data: {ex.Message}");
                return null;
            }
        }

        public List<UserViewModel> GetUserList()
        {
            try
            {
                var userList = _context.userViewModels.FromSqlRaw("CALL getUsers").ToList();

                if (userList.Count == 0 || userList == null)
                {
                    return new List<UserViewModel>();
                }
                else
                {
                    return userList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured" + ex.Message);
                return new List<UserViewModel>();
            }
        }
        public List<Role> GetRole()
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

        public int InsertUser(Users u)
        {
            int status;
            try
            {
                var parameter = new List<MySqlParameter>();

                parameter.Add(new MySqlParameter("@p_userName", u.userName));
                parameter.Add(new MySqlParameter("@p_password", u.password));
                parameter.Add(new MySqlParameter("@p_roleId", u.roleId));
                parameter.Add(new MySqlParameter("@p_createdBy", u.createdBy));

                var query = "CALL InsertUser(@p_userName, @p_password, @p_roleId, @p_createdBy)";

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
