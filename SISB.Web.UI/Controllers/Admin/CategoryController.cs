using Microsoft.AspNetCore.Mvc;
using SISB.Facade.Implementation;
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
        public async Task<IActionResult> Index()
        {
            var category= await _categoryFacade.GetCategoriesAsync();
            return View(category);
        }
    }
}
