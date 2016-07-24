using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ForecastWeatherLibrary.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ForecastWeatherLibrary.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private const string ForecastRequestUrlTemplate = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&cnt={1}&APPID=" + ApiKey;

        private const string ApiKey = "aaeff27c98b5921d1e611514dfdc116a";

        
        public async Task<Forecast> GetForecast(string city, int days)
        {
            Forecast forecast = null;
            string uri = String.Format(ForecastRequestUrlTemplate, city, days);

            using (HttpClient httpClient = new HttpClient())
            {
                 forecast = JsonConvert.DeserializeObject<Forecast>(await httpClient.GetStringAsync(uri));
            }
            return forecast;
        }
    }
}