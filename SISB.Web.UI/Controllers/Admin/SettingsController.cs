using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
