using Core.Models;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceApi : IServiceApi
    {
        private static string _user;
        private static string _password;
        private static string _baseurl;
        private static string _token;

        public ServiceApi()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _user = builder.GetSection("ApiSettings:user").Value;
            _password = builder.GetSection("ApiSettings:password").Value;
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task Authenticate()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var credentials = new UserInfo() { Username = _user, Password = _password };
            var content = new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Account/login", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserResult>(jsonResponse);
            if (result is { Token: { } }) _token = result.Token;
        }


        public async Task<List<Weather>> Lista()
        {
            List<Weather> list = new List<Weather>();

            await Authenticate();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.GetAsync("/api/Weathers");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Weather>>(jsonResponse);
                if (result != null) list = result.ToList();
            }
            return list;
        }

        public async Task<Weather> GetWeather(int idWeather)
        {
            var apiUrl = $"api/Weathers/{idWeather}";

            Weather weather = new Weather();

            await Authenticate();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResult>(jsonResponse);
                if (result != null) weather = result.Weather;
            }

            return weather;
        }

        public async Task<bool> Save(Weather weather)
        {
            var apiUrl = "api/Weathers/";
            bool respuesta = false;
            await Authenticate();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var content = new StringContent(JsonConvert.SerializeObject(weather), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
                respuesta = true;
            return respuesta;
        }

        public async Task<bool> Edit(Weather weather)
        {
            var apiUrl = "api/Weathers/edit/";
            bool respuesta = false;
            await Authenticate();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var content = new StringContent(JsonConvert.SerializeObject(weather), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
                respuesta = true;
            return respuesta;
        }

        public async Task<bool> Delete(int idWeather)
        {
            var apiUrl = $"api/Weathers/{idWeather}";
            bool respuesta = false;
            await Authenticate();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.DeleteAsync(apiUrl);

            if (response.IsSuccessStatusCode)
                respuesta = true;
            return respuesta;
        }
    }
}
