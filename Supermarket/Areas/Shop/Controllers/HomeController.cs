using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.DtoObjects.ViewModels.Cart;
using Supermarket.Core.DtoObjects.ViewModels.Product;
using Supermarket.Core.Services.EntityServices.Interfaces;
using System.Diagnostics;

namespace Supermarket.Web.Controllers.Shop
{
    public class HomeController : BaseShopController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();

            return View();
        }

        public IActionResult ShopGrid()
        {
            ViewBag.Category = string.IsNullOrWhiteSpace(Request.Query["category"]) ? 
                "All categories" : Request.Query["category"].ToString();
            
            
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> ProductDetail(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            var model = new ProductDetailsVM()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                InStock = product.Quantity > 0
            };

            return View(model);
        }

        public async Task<IActionResult> Cart()
        {
            var cookie = DecodeCartCookie(Request.Cookies.FirstOrDefault(c => c.Key == "Cart"));

            var model = new CartPageVm();
            foreach (var key in cookie)
            {
                var product = await _productService.GetByIdAsync(Guid.Parse(key.Key));

                model.Items.Add(new()
                {
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Quantity = key.Value
                });
            }

            return View(model);
        }


        protected Dictionary<string, int> DecodeCartCookie(KeyValuePair<string, string> cookie)
        {
            if (cookie.Equals(new KeyValuePair<string, string>()))
            {
                cookie = new("Cart", "");
            }

            return cookie.Value.Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x.Split("=")[0], x => int.Parse(x.Split("=")[1]));
        }

    }
}