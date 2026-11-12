using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
