using Microsoft.AspNetCore.Mvc;

namespace DTSMCC_WebApp.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorize()
        {
            return View();
        }
    }
}
