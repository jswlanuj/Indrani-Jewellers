using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Indrani_Jewellers.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerService _customerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private int userId => Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

        public CustomerController(CustomerService customerService, IHttpContextAccessor httpContextAccessor)
        {
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var list = _customerService.GetAllCustomerList().ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            try
            {
                string customerCode = c.CustomerName.Substring(0, 2).ToUpper() + "IJ" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");

                int status = _customerService.InsertCustomer(c, customerCode, userId);

                if (status == 1)
                {
                    TempData["success"] = "New customer created successfully";
                    TempData["Valid"] = "1";
                }
                else
                {
                    TempData["success"] = "Failed to create new customer";
                    TempData["Valid"] = "0";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
