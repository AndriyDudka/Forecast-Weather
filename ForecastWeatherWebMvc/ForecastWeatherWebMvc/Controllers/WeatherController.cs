using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ForecastWeatherApp.EntityContext;
using ForecastWeatherApp.EntityService;
using ForecastWeatherApp.Models;
using ForecastWeatherLibrary.DTO;
using ForecastWeatherLibrary.Service;
using City = ForecastWeatherApp.Models.City;

namespace ForecastWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            _weatherService = new WeatherService();
        }

        // GET: /Weather/Index
        public ActionResult Index()
        {          
            return View();
        }

        // POST: /Weather/ForecastWeather
        [HttpPost]
        public async Task<ActionResult> ForecastWeather(int days, string city, string searchcity, 
                                                        string submit, string edit)
        {          
            Forecast forecast = string.IsNullOrEmpty(searchcity)
                ? await _weatherForecastService.GetForecast(city, days)
                : await _weatherForecastService.GetForecast(searchcity, days);
          
            await _weatherService.AddHistoryOfSearch(forecast);

            return string.IsNullOrEmpty(submit) ? View("EditListOfCity") : View(forecast);
        }

        // GET: /Weather/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Weather/Create
        [HttpPost]
        public async Task<ActionResult> Create(City city)
        {
            await _weatherService.AddNewCity(city);
                                
            return Redirect("index");
        }

        // GET: Weather/Delete
        public async Task<ActionResult> Delete(string name)
        {                            
            return View(await _weatherService.FindCity(name));
        }

        //POST: Weather/Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteCity(string name)
        {
             await _weatherService.DeleteCity(name);
                    
            return Redirect("index");
        }
    }
}