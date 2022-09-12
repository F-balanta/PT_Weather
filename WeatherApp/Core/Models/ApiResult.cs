using System.Collections.Generic;

namespace Core.Models
{
    public class ApiResult
    {
        public List<Weather> Weathers { get; set; }
        public Weather Weather { get; set; }
    }
}