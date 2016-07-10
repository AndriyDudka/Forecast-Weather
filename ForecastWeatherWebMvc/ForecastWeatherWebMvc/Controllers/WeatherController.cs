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
        public ActionResult Index(int days, string city, string searchcity)
        {
            Forecast forecast = searchcity == ""
                ? _weatherForecastService.GetForecast(city, days)
                : _weatherForecastService.GetForecast(searchcity, days);
            return View("ForecastWeather", forecast);
        }
    }
}