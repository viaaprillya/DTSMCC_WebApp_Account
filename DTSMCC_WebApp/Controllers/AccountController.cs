using API.Repositories.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DTSMCC_WebApp.Controllers
{
    public class AccountController : Controller
    {
        HttpClient HttpClient;
        string address;

        public AccountController()
        {
            this.address = "https://localhost:44322/API/Account/";
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(address)
            };
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.data.Role);
                return RedirectToAction("Index", "AdminPanel");
            }
            return View();
        }

        public IActionResult Registrasi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrasi(Register register)
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPut]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            return View();
        }






    }
}
