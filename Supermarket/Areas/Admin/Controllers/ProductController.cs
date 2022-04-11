using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;

namespace Supermarket.Web.Controllers.Admin
{
    public class ProductController : BaseAdminController
    {
        protected IProductService _productService;
        protected ICategoryService _categoryService;

        public ProductController(IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
            var product = await _productService.GetByIdAsync(id);

            return View(product);
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                ViewBag.Categories = await _categoryService.GetAllAsync();

                var product = new Product()
                {
                    Name = collection["name"],
                    Quantity = int.Parse(collection["quantity"]),
                    Price = decimal.Parse(collection["price"]),
                    Description = collection["description"],
                    ImageUrl = collection["imageurl"],
                    CategoryId = Guid.Parse(collection["categoryid"])
                };

                ModelState.ClearValidationState(nameof(Product));
                if (!TryValidateModel(product, nameof(Product)))
                {
                    return View();
                }

                await _productService.CreateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Update/5
        public async Task<ActionResult> Update(Guid id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }

        // POST: ProductController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(Guid id, IFormCollection collection)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);

                product.Name = collection["name"];
                product.Quantity = int.Parse(collection["quantity"]);
                product.Price = decimal.Parse(collection["price"]);
                product.Description = collection["description"];
                product.ImageUrl = collection["imageurl"];
                product.CategoryId = Guid.Parse(collection["categoryid"]);

                ModelState.ClearValidationState(nameof(Product));
                if (!TryValidateModel(product, nameof(Product)))
                {
                    return View();
                }

                await _productService.UpdateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                await _productService.DeleteAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
