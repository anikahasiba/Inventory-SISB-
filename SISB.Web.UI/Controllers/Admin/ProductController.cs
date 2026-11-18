using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISB.Entities;
using SISB.Facade.Interface;
using SISB.Web.UI.Models;

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
            var categorys = await _categoryFacade.GetAllAsync();
            var suppliers = await _supplierFacade.GetSuppliersAsync();

            ProductSupplierCategory ProductInfo = new ProductSupplierCategory();
            ProductInfo.product = products;
            ProductInfo.supplier = suppliers;
            ProductInfo.category = categorys;

            ViewBag.ActiveProductCount = products.Count(x => x.IsActive);
            ViewBag.NeedAttentions = products.Count(p => p.StockCount <= p.ReorderLevel);
            return View(ProductInfo);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return View(new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var flag = await _productFacade.IsSkuExistsAsync(product.SKU);
            if (product.CategoryId <= 0 || product.PreferredSupplierId <= 0 || flag)
            {
                await LoadDropdowns();
                return View(product);
            }
            product.IsActive = true;
            product.WAC = 0;

            await _productFacade.AddProductAsync(product);

            TempData["SuccessMessage"] = "Product added successfully!";

            return RedirectToAction(nameof(Index));
        }
        private async Task LoadDropdowns()
        {
            var categories = await _categoryFacade.GetAllAsync();
            var suppliers = await _supplierFacade.GetSuppliersAsync();

            ViewBag.Categories = new SelectList(
                categories,
                "CategoryId",
                "Name"
            );

            ViewBag.Suppliers = new SelectList(
                suppliers,
                "SupplierId",
                "Name"
            );
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productFacade.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await LoadDropdowns();

            return View(product);
        }

        [HttpPost]
        [RequireAntiforgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (product.CategoryId <= 0 || product.PreferredSupplierId<=0)
            {
                await LoadDropdowns();
                return View(product);
            }

            var result = await _productFacade.UpdateProductAsync(product);

            if (!result)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = "Product updated successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}