using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Web.UI.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        // READ ALL
        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            var categories = await _categoryFacade.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                categories = categories
                    .Where(c => c.Name.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewBag.Search = search;

            return View(categories);
        }

        // READ SINGLE FOR EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryFacade.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            await LoadParentCategories(id);

            return View(category);
        }

        // ADD PAGE
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadParentCategories();

            return View(new Category());
        }

        // ADD DATA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                await LoadParentCategories();
                return View(category);
            }

            bool result = await _categoryFacade.AddAsync(category);

            if (!result)
            {
                ModelState.AddModelError(
                    "Name",
                    "Category name already exists or selected parent is invalid.");

                await LoadParentCategories();

                return View(category);
            }

            TempData["Success"] = "Category added successfully!";

            return RedirectToAction(nameof(Index));
        }

        // EDIT DATA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Category category)
        {
            if (id != category.CategoryId)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                await LoadParentCategories(id);
                return View(category);
            }

            bool result = await _categoryFacade.UpdateAsync(category);

            if (!result)
            {
                ModelState.AddModelError(
                    "",
                    "Unable to update category. Check the category name and parent.");

                await LoadParentCategories(id);

                return View(category);
            }

            TempData["Success"] = "Category updated successfully!";

            return RedirectToAction(nameof(Index));
        }

        // LOAD MAIN CATEGORIES FOR DROPDOWN
        private async Task LoadParentCategories(int? excludeId = null)
        {
            var categories = await _categoryFacade.GetAllAsync();

            var parents = categories
                .Where(c =>
                    !c.ParentCategoryId.HasValue &&
                    (!excludeId.HasValue ||
                     c.CategoryId != excludeId.Value))
                .OrderBy(c => c.Name)
                .ToList();

            ViewBag.ParentCategories = new SelectList(
                parents,
                "CategoryId",
                "Name");
        }
    }
}