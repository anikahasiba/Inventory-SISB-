using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
