using Microsoft.AspNetCore.Mvc;

namespace DTSMCC_WebApp.Controllers
{
    public class SuccessPageController : Controller
    {
        public IActionResult RegistrationSucceded()
        {
            return View();
        }

        public IActionResult ChangePasswordSucceded()
        {
            return View();
        }
    }
}
