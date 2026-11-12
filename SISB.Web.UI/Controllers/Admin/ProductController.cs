using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacade _productFacade;
        private readonly ICategoryFacade _categoryFacade;
        private readonly ISupplierFacade _supplierFacade;

        public ProductController(
            IProductFacade productFacade,
            ICategoryFacade categoryFacade,
            ISupplierFacade supplierFacade)
        {
            _productFacade = productFacade;
            _categoryFacade = categoryFacade;
            _supplierFacade = supplierFacade;
        }

        // GET: Product/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productFacade.GetProductsAsync();
            return View(products);
        }

        
    }
}