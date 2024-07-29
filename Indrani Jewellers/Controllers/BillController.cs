using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class BillController : Controller
    {
        private readonly ProductSeriveces _productServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<BillController> _logger;

        public BillController(ILogger<BillController> logger, ProductSeriveces productServices, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _productServices = productServices;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GenerateInvoice()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GenerateInvoice(GenerateInvoice generateInvoice)
        {
            return View();
        }
    }
}
