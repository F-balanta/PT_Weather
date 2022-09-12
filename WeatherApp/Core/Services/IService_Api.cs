using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IServiceApi
    {
        Task<List<Weather>> Lista();
        Task<Weather> GetWeather(int idWeather);
        Task<bool> Save(Weather weather);
        Task<bool> Edit(Weather weather);
        Task<bool> Delete(int idWeather);
    }
}
