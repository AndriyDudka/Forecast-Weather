using System.Web.Mvc;
using ForecastWeatherLibrary.DTO;
using ForecastWeatherLibrary.Service;

namespace ForecastWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }


        // GET: /Weather/Index
        public ActionResult Index()
        {            
            return View();
        }

        // POST: /Weather/Index
        [HttpPost]
        public ActionResult ForecastWeather(int days, string city, string searchcity, string submit, string edit)
        {          
            Forecast forecast = string.IsNullOrEmpty(searchcity)
                ? _weatherForecastService.GetForecast(city, days)
                : _weatherForecastService.GetForecast(searchcity, days);

            return string.IsNullOrEmpty(submit) ? View("EditListOfCity") : View(forecast);
        }
    }
}