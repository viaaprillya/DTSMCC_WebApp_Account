using Microsoft.AspNetCore.Mvc;

namespace DTSMCC_WebApp.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
