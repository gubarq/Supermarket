using Microsoft.AspNetCore.Mvc;

namespace Supermarket.Web.Controllers.Admin
{
    public class HomeController: BaseAdminController
    {
        public IActionResult Index()
        {
            return View("Areas/Admin/Views/Pages/Index.cshtml");
        }
    }
}
