using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ForecastWeatherApp.EntityContext;
using ForecastWeatherApp.Models;
using ForecastWeatherLibrary.DTO;
using Newtonsoft.Json;

namespace ForecastWeatherApp.EntityService
{
    public class WeatherService:IWeatherService
    {     
        public async Task AddNewCity(City city)
        {
            using (var context = new WeatherContext())
            {
                foreach (var p in context.Cities)
                {
                    if (p.Name == city.Name) return;
                }

                context.Cities.Add(city);
                await context.SaveChangesAsync();
            }    
        }

        public async Task<City> FindCity(string name)
        {
            using (var context = new WeatherContext())
            {
                foreach (var p in context.Cities)
                {
                    if (p.Name == name) return p;
                }
            }         
            return null;
        }

        public async Task DeleteCity(string name)
        {
            using (var context = new WeatherContext())
            {
                var p = await context.Cities.SingleOrDefaultAsync(x => x.Name == name);

                if (p != null)
                {
                    context.Cities.Remove(p);
                    await context.SaveChangesAsync();
                }
            }           
        }

        public async Task AddHistoryOfSearch(Forecast forecast)
        {
            using (var context = new WeatherContext())
            {
                var history = new HistoryOfSearch
                {
                    Date = DateTime.Now,
                    Json = new JavaScriptSerializer().Serialize(forecast)
                };

                context.HistoryOfSearches.Add(history);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<HistoryOfSearch>> ListOfSearches(string city)
        {
            List<HistoryOfSearch> listOfSearch = new List<HistoryOfSearch>();
            using (var context = new WeatherContext())
            {
                foreach (var p in context.HistoryOfSearches)
                {
                    var name = await JsonConvert.DeserializeObjectAsync<Forecast>(p.Json);
                    if (name.City.Name == city) listOfSearch.Add(p);
                }
            }
            return listOfSearch;
        }

        public async Task<Forecast> FindForecastWeather(HistoryOfSearch historyOfSearch)
        {          
                return JsonConvert.DeserializeObject<Forecast>(historyOfSearch.Json);               
        }
    }
}