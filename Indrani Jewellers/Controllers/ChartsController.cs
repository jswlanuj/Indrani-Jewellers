using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ProductSeriveces _productServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;

        public ChartsController(ILogger<ProductController> logger, ProductSeriveces productServices, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _productServices = productServices;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public IActionResult Home()
        {
            List<ProductMasterModel> productList = _productServices.GetProductMasterList();
            return View(productList);
        }


        public IActionResult Bar()
        {
            List<ProductMasterModel> productList = _productServices.GetProductMasterList();
            return View(productList);
        }

        public IActionResult Line()
        {
            List<ProductMasterModel> productList = _productServices.GetProductMasterList();
            return View(productList);
        }

        public IActionResult DoughnetChart()
        {
            List<ProductMasterModel> productList = _productServices.GetProductMasterList();
            return View(productList);
        }

        public IActionResult AreaChart()
        {
            List<ProductMasterModel> productList = _productServices.GetProductMasterList();
            return View(productList);
        }



    }
}
