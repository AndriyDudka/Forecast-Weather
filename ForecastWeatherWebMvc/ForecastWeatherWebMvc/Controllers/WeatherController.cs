using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ForecastWeatherApp.EntityContext;
using ForecastWeatherApp.Models;
using ForecastWeatherLibrary.DTO;
using ForecastWeatherLibrary.Service;
using City = ForecastWeatherApp.Models.City;

namespace ForecastWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        private WeatherLogic _weatherLogic;

        public WeatherController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }


        // GET: /Weather/Index
        public ActionResult Index()
        {          
            return View();
        }

        // POST: /Weather/ForecastWeather
        [HttpPost]
        public async Task<ActionResult> ForecastWeather(int days, string city, string searchcity, string submit, string edit)
        {          
            Forecast forecast = string.IsNullOrEmpty(searchcity)
                ? await _weatherForecastService.GetForecast(city, days)
                : await _weatherForecastService.GetForecast(searchcity, days);

            using (var context = new WeatherContext())
            {
                var history = new HistoryOfSearch
                {                  
                    Date = DateTime.Now,
                    Json = new JavaScriptSerializer().Serialize(forecast)
                };

                context.HistoryOfSearches.Add(history);
                context.SaveChanges();
            }

            return string.IsNullOrEmpty(submit) ? View("EditListOfCity") : View(forecast);
        }

        // GET: /Weather/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Weather/Create
        [HttpPost]
        public ActionResult Create(City city)
        {
            using (var context = new WeatherContext())
            {
                _weatherLogic = new WeatherLogic(context);
                if (!_weatherLogic.FindCity(city))
                {
                    context.Cities.Add(city);
                    context.SaveChanges();
                }
                
            }
            return Redirect("index");
        }

        // GET: Weather/Delete
        public ActionResult Delete(string name)
        {
            
            City city = null;
            using (var context = new WeatherContext())
            {
                _weatherLogic = new WeatherLogic(context);
                city = _weatherLogic.SomeMethod(name);
            }
            return View(city);
        }

        //POST: Weather/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCity(string name)
        {
            using (var context = new WeatherContext())
            {
                _weatherLogic = new WeatherLogic(context);
                _weatherLogic.DeleteCity(name);
            }
            return Redirect("index");
        }
    }
}