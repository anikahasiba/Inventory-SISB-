using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Manager
{
    public class MDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
