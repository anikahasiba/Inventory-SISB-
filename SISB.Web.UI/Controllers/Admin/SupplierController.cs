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
        public async Task<IActionResult> Index(string? search,string? paymentTerms,bool showInactive = false)
        {
            var suppliers = await _supplierFacade.GetSuppliersAsync();

            // Summary calculations - before filtering
            ViewBag.TotalSuppliers = suppliers.Count;

            ViewBag.ActiveSuppliers =
                suppliers.Count(s => s.IsActive);

            ViewBag.TotalPayable =
                suppliers.Where(s => s.Balance > 0)
                         .Sum(s => s.Balance);

            ViewBag.SuppliersWithDue =
                suppliers.Count(s => s.Balance > 0);

            ViewBag.AverageLeadTime =
                suppliers.Any()
                    ? suppliers.Average(s => s.LeadTimeDays)
                    : 0;

            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                suppliers = suppliers
                    .Where(s =>
                        s.Name.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase) ||
                        (s.Phone != null && s.Phone.Contains(search)))
                    .ToList();
            }

            // Payment terms filter
            if (!string.IsNullOrWhiteSpace(paymentTerms))
            {
                suppliers = suppliers
                    .Where(s => s.PaymentTerms == paymentTerms)
                    .ToList();
            }

            // Active / Inactive filter
            if (!showInactive)
            {
                suppliers = suppliers
                    .Where(s => s.IsActive)
                    .ToList();
            }

            ViewBag.Search = search;
            ViewBag.PaymentTerms = paymentTerms;
            ViewBag.ShowInactive = showInactive;

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
