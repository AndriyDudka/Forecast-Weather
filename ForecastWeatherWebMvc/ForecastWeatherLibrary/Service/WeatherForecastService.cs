using System;
using System.IO;
using System.Net;
using ForecastWeatherLibrary.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ForecastWeatherLibrary.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private const string ForecastRequestUrlTemplate = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&cnt={1}&APPID=" + ApiKey;

        private const string ApiKey = "aaeff27c98b5921d1e611514dfdc116a";

        
        public Forecast GetForecast(string city, int days)
        {
            string urlString = String.Format(ForecastRequestUrlTemplate, city, days);

            var uri = new Uri(urlString);
            
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                if (stream == null || stream == Stream.Null)
                    return null;
                
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(json))
                        return null;

                    Forecast forecast = JsonConvert.DeserializeObject<Forecast>(json);
                   
                    return forecast;
                }
            }
        }
    }
}