using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class UserController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UsersService _user;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ApplicationDbContext context, UsersService users, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = users;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            List<UserViewModel> userlist = _user.GetUserList(); 

            return View(userlist);
        }

        public IActionResult Create()
        {
            ViewBag.Role = _user.GetRole();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Users u)
        {
            int status = _user.InsertUser(u);

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

            return RedirectToAction("Index");
        }

        public JsonResult ValidateUser(string Username)
        {
            var user = _context.users.FirstOrDefault(m => m.userName == Username);

            if (user != null)
            {
                return Json(false);
            }
            return Json(true);
        }

    }
}
