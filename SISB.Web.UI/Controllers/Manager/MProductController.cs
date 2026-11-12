using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Manager
{
    public class MProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
