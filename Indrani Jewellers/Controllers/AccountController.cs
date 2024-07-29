using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersService _usersService;
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UsersService usersService, IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _usersService = usersService;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password, int? productId)
        {
            try
            {
                var loginResult = _usersService.GetUsernamePassword(userName, password);

                if (loginResult == null || loginResult.Users.Count == 0)
                {
                    TempData["success"] = loginResult?.ErrorMessage ?? "Invalid Credentials";
                    TempData["Valid"] = "0";
                    return View();
                }

                var roleResult = _usersService.GetRoles(loginResult.Users[0].roleId);

                if (roleResult == null || roleResult.Count == 0)
                {
                    TempData["success"] = loginResult.ErrorMessage ?? "Invalid Credentials";
                    TempData["Valid"] = "0";
                    return View();
                }

                // Store user session information
                HttpContext.Session.SetString("UserId", loginResult.Users[0].userId.ToString());
                HttpContext.Session.SetString("UserName", loginResult.Users[0].userName.ToString());
                HttpContext.Session.SetString("DisplayName", loginResult.Users[0].DisplayName.ToString());
                HttpContext.Session.SetString("RoleId", loginResult.Users[0].roleId.ToString());
                HttpContext.Session.SetString("RoleName", roleResult[0].role);


                return RedirectToAction("Home", "Charts");

            }
            catch (Exception ex)
            {
                TempData["success"] = "Invalid Credentials";
                TempData["Valid"] = "0";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        public JsonResult ValidateUser(string Username)
        {
            var user = _db.users.FirstOrDefault(m => m.userName == Username);

            if (user != null)
            {
                return Json(false);
            }
            return Json(true);
        }
        public IActionResult Register()
        {
            ViewBag.Role = _usersService.GetRole();

            return View();
        }


        [HttpPost]
        public IActionResult Register(Users u)
        {
            if (u.roleId == 0 || u.roleId == null)
            {
                u.roleId = 4;
            }
            int status = _usersService.InsertUser(u);

            if (status == 1)
            {
                TempData["success"] = "New user created successfully";
                TempData["Valid"] = "1";
            }
            else
            {
                TempData["success"] = "Failed to create new user";
                TempData["Valid"] = "0";
            }

            return RedirectToAction("Login");
        }
    }
}
