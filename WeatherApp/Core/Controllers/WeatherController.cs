using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            return View();
        }

        private readonly IServiceApi _serviceApi;

        public WeatherController(IServiceApi serviceApi)
        {
            _serviceApi = serviceApi;
        }

        /*
        public async Task<IActionResult> Index()
        {
            List<Weather> list = await _serviceApi.Lista();
            return View(list);
        }
        */
        public async Task<IActionResult> Weather(int idWeather)
        {
            Weather weatherModel = new Weather();
            ViewBag.Action = "Nuevo clima";
            if (idWeather != 0)
            {
                weatherModel = await _serviceApi.GetWeather(idWeather);
                ViewBag.Action = "Editar clima";
            }
            return View(weatherModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(Weather weather)
        {
            bool response = false;
            if (weather.Id != 0)
                response = await _serviceApi.Edit(weather);
            else
                response = await _serviceApi.Save(weather);



            if (response)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int idWeather)
        {
            var response = await _serviceApi.Delete(idWeather);
            if (response)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}
