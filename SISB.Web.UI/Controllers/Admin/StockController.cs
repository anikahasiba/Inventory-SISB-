using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
