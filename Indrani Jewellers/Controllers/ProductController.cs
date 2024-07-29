using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductSeriveces _productServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ProductSeriveces productServices, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _productServices = productServices;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var productList = _productServices.GetProductMasterList();
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductMasterModel pm, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");

                if (!string.IsNullOrEmpty(pm.ImageUrl))
                {
                    // Delete the old image
                    var oldImage = Path.Combine(wwwRootPath, pm.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                pm.ImageUrl = @"\images\product\" + fileName;
            }

            int status = _productServices.InsertProductMaster(pm);

            if (status == 1)
            {
                TempData["success"] = "New product created successfully";
                TempData["Valid"] = "1";
            }
            else
            {
                TempData["success"] = "Failed to create new product";
                TempData["Valid"] = "0";
            }

            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }




            var product = _productServices.GetProductMasterDataByID(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = product.FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            // Log the ImageUrl to verify the path
            _logger.LogInformation("Image URL: " + model.ImageUrl);

            return View(model);
        }



        [HttpPost]
        public IActionResult Edit(ProductMasterModel pm, IFormFile? file)
        {

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");

                if (!string.IsNullOrEmpty(pm.ImageUrl))
                {
                    // Delete the old image
                    var oldImage = Path.Combine(wwwRootPath, pm.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                pm.ImageUrl = @"\images\product\" + fileName;
            }
            int status = _productServices.UpdadteProductMaster(pm);

            if (status == 1)
            {
                TempData["success"] = "Product updated successfully";
                TempData["Valid"] = "1";
            }
            else
            {
                TempData["success"] = "Failed to update product";
                TempData["Valid"] = "0";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var Prod = _productServices.GetProductMasterDataByID(id);

                if (Prod == null)
                {
                    return NotFound();

                }
                return View(Prod.FirstOrDefault());
            }
            catch
            {
                return NotFound();

            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var Prod = _productServices.GetProductMasterDataByID(id);

                if (Prod == null)
                {
                    return NotFound();

                }
                return View(Prod.FirstOrDefault());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            int status = _productServices.DeleteproductMaster(id);

            if (status == 1)
            {
                TempData["success"] = "Product deleted successfully";
                TempData["Valid"] = "1";
            }
            else
            {
                TempData["success"] = "Failed to delete product";
                TempData["Valid"] = "0";
            }

            return RedirectToAction("Index");
        }

    }
}
