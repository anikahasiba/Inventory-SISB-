using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers
{
    public class MainHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
