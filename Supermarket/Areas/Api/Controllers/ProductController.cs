using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.DtoObjects.Api.Product;
using Supermarket.Core.Services.ActionServices.Interfaces;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;

namespace Supermarket.Web.Areas.Api.Controllers
{
    [Route("/product")]
    public class ProductController : BaseApiController
    {
        protected IProductService _productService;
        protected IDtoMappingService _dtoMappingService;

        public ProductController(IProductService productService, IDtoMappingService dtoMappingService)
        {
            _productService = productService;
            _dtoMappingService = dtoMappingService;
        }

        [HttpGet]
        [Route("/{categoryName}")]
        public async Task<IActionResult> GetProductsByCategoryName(string categoryName)
        {
            try
            {
                var products = await _productService.GetByCategoryNameAsync(categoryName);

                var productDtos = products.Select(p => _dtoMappingService.Map<Product, ProductResponseDto>(p));

                return new JsonResult(productDtos);
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}
