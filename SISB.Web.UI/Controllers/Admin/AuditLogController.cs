using Microsoft.AspNetCore.Mvc;

namespace SISB.Web.UI.Controllers.Admin
{
    public class AuditLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
