using Indrani_Jewellers.Data;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Indrani_Jewellers.Models;
using System.Reflection.Emit;

namespace Indrani_Jewellers.Controllers
{
    public class ProductDetailsController : BaseController
    {
        private readonly ProductDetailServices _productDetailServices;
        private readonly ApplicationDbContext _db;
        private readonly ProductSeriveces _productServices;

        public ProductDetailsController(ProductDetailServices productDetailServices, ApplicationDbContext db, ProductSeriveces productServices)
        {
            _productDetailServices = productDetailServices;
            _db = db;
            _productServices = productServices;
        }

        public IActionResult Index()
        {
            var productDetailsList = _productDetailServices.GetProductDetails();
            return View(productDetailsList);
        }

        public IActionResult Create()
        {
            ViewBag.ProductNames = _productServices.GetProductMasterList();
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] List<ProductDetailsModel> model)
        {
            var status = _productDetailServices.InsertProductDetails(model);

            if (status > 0)
            {
                TempData["success"] = "New products created successfully";
                TempData["valid"] = "1";
            }
            else
            {
                TempData["success"] = "Failed to create new products";
                TempData["valid"] = "0";
            }

            TempData.Keep(); 
            return Json(new { success = TempData["success"], valid = TempData["valid"] });
        }

    }
}
