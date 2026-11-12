using Microsoft.AspNetCore.Mvc;
using SISB.Entities;
using SISB.Facade.Interface;
using SISB.Facade.Implementation;

namespace SISB.Web.UI.Controllers.Admin
{
    public class SupplierController : Controller
    {
        private readonly ISupplierFacade _supplierFacade;

        public SupplierController(ISupplierFacade supplierFacade)
        {
            _supplierFacade = supplierFacade;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierFacade.GetSuppliersAsync();
            
            return View(suppliers);
        }
        public async Task<IActionResult> Create()
        {
            return View(new Supplier());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            await _supplierFacade.AddSupplierAsync(supplier);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierFacade.GetSupplierByIdAsync(id);

            if (supplier == null)
                return NotFound();

            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier supplier)
        {
            if (!ModelState.IsValid)
                return View(supplier);

            bool isUpdated = await _supplierFacade.UpdateSupplierAsync(supplier);

            if (!isUpdated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
