using Microsoft.AspNetCore.Mvc;

namespace Supermarket.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShopGrid()
        {
            return View();
        }

        public async Task<IActionResult> BlogGrid()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
    }
}
