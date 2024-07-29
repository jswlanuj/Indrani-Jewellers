using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Indrani_Jewellers.Controllers
{
    public class EmployeeController : BaseController
    {
        public readonly EmployeeServices _employeeServices;
        public readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeController(EmployeeServices employeeServices, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _employeeServices = employeeServices;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var empList = _employeeServices.GetEmployeeData();
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.State = _employeeServices.GetState();
            ViewBag.City = _employeeServices.GetCity();
            ViewBag.Country = _employeeServices.GetCountry();
            ViewBag.Role = _employeeServices.GetRoles();

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel em)
        {
            string empcode = "EMP" + em.name.Substring(0, 3) + DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            int status = _employeeServices.InsertEmployee(em, empcode);

            if (status == 1)
            {
                TempData["success"] = "New employee created successfully";
                TempData["Valid"] = "1";
            }
            else
            {
                TempData["success"] = "Failed to create new employee";
                TempData["Valid"] = "0";
            }

            return RedirectToAction("Index");
        }

        public IActionResult EmployeeEmailVerification(string email)
        {
            var data = _db.EmployeeModels.Select(e => e.email).ToList();
            bool emailExists = data.Contains(email);
            return new JsonResult(emailExists);
        }
    }
}   
