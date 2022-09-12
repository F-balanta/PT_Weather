using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace CoreMVC.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
            {

                var weathers = await GetWeathers();
                return View(weathers);
            }
        }

        public async Task<List<Weather>> GetWeathers()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            var url = "https://localhost:5001/api/weathers";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync(url);
            var res = JsonConvert.DeserializeObject<List<Weather>>(jsonStr).ToList();
            return res;
        }



        public IActionResult Create()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,CityImageUrl,Temperature,TempMin,TempMax")] Weather weathers)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
            {
                var url = "https://localhost:5001/api/weathers";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var stringContent = new StringContent(JsonConvert.SerializeObject(weathers), Encoding.UTF8, "application/json");
                await client.PostAsync(url, stringContent);
                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<IActionResult> Edit(int? id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
            {
                if (id == null)
                    return NotFound();

                var url = $"https://localhost:5001/api/weathers/{id}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var jsonStr = await client.GetStringAsync(url);
                var res = JsonConvert.DeserializeObject<Weather>(jsonStr);

                if (res == null)
                    return NotFound();
                return View(res);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,CityImageUrl,Temperature,TempMin,TempMax")] Weather weathers)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
            {
                if (id != weathers.Id)
                    return NotFound();

                var url = $"https://localhost:5001/api/weathers/{id}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var stringContent = new StringContent(JsonConvert.SerializeObject(weathers), Encoding.UTF8, "application/json");
                await client.PutAsync(url, stringContent);

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
            {
                if (id == null)
                    return NotFound();

                var url = $"https://localhost:5001/api/weathers/{id}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var jsonStr = await client.GetStringAsync(url);
                var res = JsonConvert.DeserializeObject<Weather>(jsonStr);
                if (res == null)
                    return NotFound();
                return View(res);
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
                return Redirect("~/Home/Index");
            else
            {
                var url = $"https://localhost:5001/api/weathers/{id}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                await client.DeleteAsync(url);
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
