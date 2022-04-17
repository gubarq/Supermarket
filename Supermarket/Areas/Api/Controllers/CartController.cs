using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.DtoObjects.Api.Cart;
using Supermarket.Core.DtoObjects.Api.Product;
using Supermarket.Core.Services.ActionServices.Interfaces;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;

namespace Supermarket.Web.Areas.Api.Controllers
{
    public class CartController : BaseApiController
    {
        protected IProductService _productService;
        protected IDtoMappingService _dtoMappingService;

        public CartController(IProductService productService, IDtoMappingService dtoMappingService)
        {
            _productService = productService;
            _dtoMappingService = dtoMappingService;
        }

        [HttpGet]
        [Route("/api/cartprice")]
        public async Task<IActionResult> GetCartPrice()
        {
            var cookie = DecodeCartCookie(Request.Cookies.FirstOrDefault(c => c.Key == "Cart"));

            var total = 0m;
            foreach (var key in cookie)
            {
                var product = await _productService.GetByIdAsync(Guid.Parse(key.Key));

                total += product.Price * key.Value;
            }

            return new JsonResult(new CartTotalDto() { Total = total });
        }


        [HttpPost]
        [Route("/api/cart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartProductDto dto)
        {
            try
            {
                var product = await _productService.GetByIdAsync(Guid.Parse(dto.Id));

                if (product.Quantity < dto.Qu)
                {
                    return BadRequest();
                }

                var cookie = DecodeCartCookie(Request.Cookies.FirstOrDefault(c => c.Key == "Cart"));

                if (cookie.ContainsKey(dto.Id))
                {
                    cookie[dto.Id] += dto.Qu;
                }
                else
                {
                    cookie[dto.Id] = dto.Qu;
                }

                Response.Cookies.Append("Cart", EncodeCookie(cookie));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
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

        protected string EncodeCookie(Dictionary<string, int> cart)
            => string.Join("&", cart.Select(kvp => $"{kvp.Key}={kvp.Value}"));
    }
}
