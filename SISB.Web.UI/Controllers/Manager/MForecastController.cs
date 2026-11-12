using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Manager
{
    public class MForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
