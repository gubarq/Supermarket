using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;
using Supermarket.Web.Controllers.Shop;
using System.Security.Claims;

namespace Supermarket.Web.Areas.Shop.Controllers
{
    public class OrderController : BaseShopController
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(IProductService productService, IOrderService orderService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _orderService = orderService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder()
        {
            var cookie = DecodeCartCookie(Request.Cookies.FirstOrDefault(c => c.Key == "Cart"));

            var products = new List<OrderProduct>();

            foreach (var key in cookie)
            {
                var product = await _productService.GetByIdAsync(Guid.Parse(key.Key));
                products.Add(new()
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = key.Value,
                });
            }

            Response.Cookies.Delete("Cart");
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _orderService.PlaceOrderAsync(products, 
                 _userManager.Users.FirstOrDefault(u => u.Id.ToString() == userId));
            return Redirect("/");
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
