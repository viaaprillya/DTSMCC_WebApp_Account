using API.Repositories.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
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
            this.address = "https://localhost:5001/api/Account/";
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
            address = "https://localhost:5001/api/Account/Login";
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", response.data.Role);
                return RedirectToAction("Authorize", "AdminPanel");
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        public IActionResult Registrasi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrasi(Register register)
        {
            address = "https://localhost:5001/api/Account/Register";
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientNoData>(await result.Content.ReadAsStringAsync());
                return RedirectToAction("RegistrationSucceded", "SuccessPage");
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ChangePassword changePassword)
        {
            address = "https://localhost:5001/api/Account/ChangePassword";
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePassword), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientNoData>(await result.Content.ReadAsStringAsync());
                return RedirectToAction("ChangePasswordSucceded", "SuccessPage");
            }
            return View();
        }






    }
}
