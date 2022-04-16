using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> ShopGrid()
        {
            ViewBag.Category = string.IsNullOrWhiteSpace(Request.Query["category"]) ? 
                "All categories" : Request.Query["category"].ToString();
            
            
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}