using System;
using CoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JsonResult = CoreMVC.Models.JsonResult;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(UserInfo user)
        {
            using var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:5001/api/Users/login", content))
            {
                var sc = response.StatusCode;
                string token = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<JsonResult>(token);

                
                if (sc == HttpStatusCode.Unauthorized || string.IsNullOrEmpty(result.token))
                {
                    ViewBag.Message = "Credenciales inválidas. Inténtelo de nuevo";
                    return Redirect("~/Home/Index");
                }
                HttpContext.Session.SetString("JWToken", result.token);
            }

            //return Ok(user);
            return Redirect("~/Weather/Index");
        }

        public async Task<IActionResult> Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
