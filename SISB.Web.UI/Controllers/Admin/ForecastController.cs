using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class ForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
