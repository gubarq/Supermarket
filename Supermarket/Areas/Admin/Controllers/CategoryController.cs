using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;

namespace Supermarket.Web.Controllers.Admin
{
    public class CategoryController : BaseAdminController
    {
        protected ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var category = new Category()
                {
                    Name = collection["name"],
                    IsFeatured = collection["isfeatured"].Contains("featured")
                };

                ModelState.ClearValidationState(nameof(Category));
                if (!TryValidateModel(category, nameof(Category)))
                {
                    return View();
                }

                await _categoryService.CreateAsync(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Update/5
        public async Task<ActionResult> Update(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category);
        }

        // POST: CategoryController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(Guid id, IFormCollection collection)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);

                category.Name = collection["name"];
                category.IsFeatured = collection["isfeatured"].Contains("featured");

                ModelState.ClearValidationState(nameof(Category));
                if (!TryValidateModel(category, nameof(Category)))
                {
                    return View();
                }

                await _categoryService.UpdateAsync(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                await _categoryService.DeleteAsync(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
