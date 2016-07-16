using Newtonsoft.Json;

namespace ForecastWeatherLibrary.DTO
{
    public class CityInformation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }
    }
}
