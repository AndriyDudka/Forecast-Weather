using System.Collections.Generic;
using Newtonsoft.Json;

namespace ForecastWeatherLibrary.DTO
{
    public class DailyForecast
    {
        [JsonProperty("dt")]
        public long Daytime { get; set; } //UNIX TIME.

        [JsonProperty("temp")]
        public Temp Temperature { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Degrees { get; set; }

        [JsonProperty("clouds")]
        public int Clouds { get; set; }
    }
}
