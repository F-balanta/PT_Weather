namespace Domain
{
    public class Weather
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string CityImageUrl { get; set; }
        public int Temperature { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
    }
}
