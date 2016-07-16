using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ForecastWeatherApp.EntityContext;
using ForecastWeatherApp.Models;
using ForecastWeatherLibrary.DTO;
using ForecastWeatherLibrary.Service;
using Newtonsoft.Json;

namespace ForecastWeatherApp.Controllers
{
    public class HistoryOfSearchController : Controller
    {
        // GET: HistoryOfSearch/index
        public ActionResult Index()
        {
            return View();
        }

        // POST: HistoryOfSearch/SeeHistory
        [HttpPost]
        public ActionResult SeeHistory(string city)
        {
            var listOfSearch = new List<HistoryOfSearch>();
            using (var context = new WeatherContext())
            {
                foreach (var p in context.HistoryOfSearches)
                {
                    var name = JsonConvert.DeserializeObject<Forecast>(p.Json);
                    if (name.City.Name == city) listOfSearch.Add(p);
                }
            }
            return View(listOfSearch);
        }

        public ActionResult Forecast(HistoryOfSearch historyOfSearch)
        {
            Forecast forecast = JsonConvert.DeserializeObject<Forecast>(historyOfSearch.Json);
            return View("~/Views/Weather/ForecastWeather.cshtml", forecast);
        }
    }
}