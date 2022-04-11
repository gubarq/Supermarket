using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;

namespace Supermarket.Web.Controllers.Admin
{
    public class ProductController : BaseAdminController
    {
        protected IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            ViewBag.Products = await _productService.GetAllAsync();
            return View();
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.Product = await _productService.GetByIdAsync(id);
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var product = new Product()
                {
                    Name = collection["name"],
                    Quantity = int.Parse(collection["quantity"]),
                    Price = decimal.Parse(collection["price"]),
                    Description = collection["description"],
                    ImageUrl = collection["imageurl"]
                };

                await _productService.CreateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
