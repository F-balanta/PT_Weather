using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Services;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceApi _service;

        public HomeController(IServiceApi service)
        {
            _service = service;
        }

        public async Task<IActionResult> LoginUser(UserInfo user)
        {
            using var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:5001/api/Users/login", content))
            {
                string token = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("JWToken", token);
            }

            return Ok(user);
            //return Redirect("~/Weather/Index");
        }

        public async Task<IActionResult> Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public Task<IActionResult> Privacy() => Task.FromResult<IActionResult>(View());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
