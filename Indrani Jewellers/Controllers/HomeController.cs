using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class HomeController : Controller
    {
        public readonly LoanService _loanServices;
        public readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProductSeriveces _productServices;
        private readonly ILogger<HomeController> _logger;

        private int userId => Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

        public HomeController(ILogger<HomeController> logger, ProductSeriveces productServices, LoanService loanServices, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
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

        [HttpPost]
        public IActionResult Details(ProductMasterModel pm)
        {

            return View();
        }
    }
}
