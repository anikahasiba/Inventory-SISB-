using Microsoft.AspNetCore.Mvc;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Web.UI.Controllers.Admin
{
    public class CustomerController : Controller
    {
        private readonly ICustomerFacade _customerFacade;

        public CustomerController(ICustomerFacade customerFacade)
        {
            _customerFacade = customerFacade;
        }

        // =========================
        // READ
        // =========================
        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            var customers = await _customerFacade.GetCustomersAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                customers = customers
                    .Where(c =>
                        c.Name.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase) ||
                        (c.Phone != null &&
                         c.Phone.Contains(search)))
                    .ToList();
            }

            ViewBag.Search = search;

            ViewBag.TotalCustomers = customers.Count;

            ViewBag.ActiveCustomers =
                customers.Count(c => c.IsActive);

            ViewBag.TotalDues = customers
                .Where(c => c.DueBalance > 0)
                .Sum(c => c.DueBalance);

            ViewBag.CreditGiven = customers
                .Sum(c => c.CreditLimit);

            ViewBag.NearCreditLimit = customers.Count(c =>
                c.CreditLimit > 0 &&
                c.DueBalance >= c.CreditLimit * 0.8m);

            return View(customers);
        }

        // =========================
        // CREATE - GET
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            var customer = new Customer
            {
                IsActive = true,
                CreditLimit = 0,
                DueBalance = 0
            };

            return View(customer);
        }

        // =========================
        // CREATE - POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            ModelState.Remove(nameof(customer.DueBalance));

            if (!ModelState.IsValid)
                return View(customer);

            try
            {
                await _customerFacade.AddCustomerAsync(customer);

                TempData["Success"] =
                    "Customer added successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(customer);
            }
        }

        // =========================
        // EDIT - GET
        // =========================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerFacade
                .GetCustomerByIdAsync(id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // =========================
        // EDIT - POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Customer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest();

            ModelState.Remove(nameof(customer.DueBalance));

            if (!ModelState.IsValid)
                return View(customer);

            var result = await _customerFacade
                .UpdateCustomerAsync(customer);

            if (!result)
            {
                ModelState.AddModelError(
                    "",
                    "Customer could not be updated.");

                return View(customer);
            }

            TempData["Success"] =
                "Customer updated successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}