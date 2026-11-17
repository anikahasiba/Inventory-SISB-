using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class MysalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
