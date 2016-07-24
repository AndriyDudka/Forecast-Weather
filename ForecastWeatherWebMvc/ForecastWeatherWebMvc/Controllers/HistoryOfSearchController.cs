using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ForecastWeatherApp.EntityContext;
using ForecastWeatherApp.EntityService;
using ForecastWeatherApp.Models;
using ForecastWeatherLibrary.DTO;
using Newtonsoft.Json;

namespace ForecastWeatherApp.Controllers
{
    public class HistoryOfSearchController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HistoryOfSearchController()
        {
            _weatherService = new WeatherService();
        }

        // GET: HistoryOfSearch/index
        public ActionResult Index()
        {
            return View();
        }

        // POST: HistoryOfSearch/SeeHistory
        [HttpPost]
        public async Task<ActionResult> SeeHistory(string city)
        {
            var listOfSearch = _weatherService.ListOfSearches(city);
            
            return View(await listOfSearch);
        }

        // GET: HistoryOfSearch/SeeHistory        
        public async Task<ActionResult> Forecast(HistoryOfSearch historyOfSearch)
        {
            var forecast =  _weatherService.FindForecastWeather(historyOfSearch);
   
            return View("~/Views/Weather/ForecastWeather.cshtml", await forecast);
        }
    }
}