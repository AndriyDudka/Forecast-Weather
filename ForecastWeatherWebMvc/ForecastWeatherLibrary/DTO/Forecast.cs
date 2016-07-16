using System.Collections.Generic;
using Newtonsoft.Json;

namespace ForecastWeatherLibrary.DTO
{
    public class Forecast
    {
        [JsonProperty("city")]
        public CityInformation City { get; set; }      

        [JsonProperty("cnt")]
        public int cnt { get; set; }
        
        [JsonProperty("list")]
        public List<DailyForecast> List { get; set; }

        #region ResponseDetails
        [JsonProperty("cod")]
        public double ResponseCode { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }
        #endregion 
    }
}