using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Web.Controllers.Admin;

namespace Supermarket.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseAdminController
    {
        protected IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Orders = await _orderService.GetAllAsync();
            return View();
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return View(order);
        }
    }
}
