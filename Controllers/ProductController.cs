using Assignment_12_1.Models;
using Assignment_12_1.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;

namespace Assignment_12_1.Controllers
{
    public class ProductController : Controller
    {
        private IproductRepository productR;
        private iFileUpload fileUpload;
        public ProductController(IproductRepository productR, iFileUpload fileUpload)
        {
            this.productR = productR;
            this.fileUpload = fileUpload;
        }
        [Authorize]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Products = productR.GetProducts();
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            Product product = new Product();
            product.Id = productR.GetMaxId();
            return View(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(Product obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (await fileUpload.UploadFile(file))

                {
                    obj.ImageName = fileUpload.FileName;
                    productR.AddProduct(obj);
                    return RedirectToRoute(new { Action = "Index", Controller = "Product" });
                }
                else
                {
                    ViewBag.ErrorMessage = "File Upload Failed";
                    return View(obj);
                }
            }
            ViewBag.ErrorMessage = "Error adding product";
            return View(obj);
        }

        [Authorize]
        public IActionResult Details(int? id)
        {
            var products = productR.GetProduct(id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var prod = productR.GetProduct(id);
            return View(prod);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Product obj)
        {
            if(ModelState.IsValid)
            {
                productR.UpdateProduct(obj);
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error adding product";
            return View(obj);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            productR.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
