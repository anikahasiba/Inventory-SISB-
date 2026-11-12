using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
