using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTSMCC_WebApp.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Authorize()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role.Equals("Employee"))
            {
                return View();
            }
            return RedirectToAction("Unauthorized","ErrorPage");
        }
    }
}
