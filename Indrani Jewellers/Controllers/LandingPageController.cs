using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class LandingPageController : Controller
    {
        public readonly LoanService _loanServices;
        public readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProductSeriveces _productServices;
        private readonly ILogger<LandingPageController> _logger;

        public LandingPageController(ILogger<LandingPageController> logger, ProductSeriveces productServices, LoanService loanServices, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _loanServices = loanServices;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _productServices = productServices;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var productList = _productServices.GetProductMasterList();
            return View(productList);
        }

        public IActionResult Loan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loan(string c)
        {
            var user = _db.Loans.FirstOrDefault(m => m.CustomerID == c);

            if (user != null)
            {
                return Json(false);
            }
            return Json(true);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _db.product_master.FirstOrDefault(m => m.productId == id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }


            return View(data);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Details(ProductMasterModel pm)
        {
            return View();
        }
    }
}
