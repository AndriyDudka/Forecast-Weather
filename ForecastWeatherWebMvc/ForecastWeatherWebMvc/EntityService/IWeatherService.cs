using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastWeatherApp.Models;
using ForecastWeatherLibrary.DTO;

namespace ForecastWeatherApp.EntityContext
{
    interface IWeatherService
    {
        Task AddNewCity(City city);

        Task<City> FindCity(string name);

        Task DeleteCity(string name);

        Task AddHistoryOfSearch(Forecast forecast);

        Task<List<HistoryOfSearch>> ListOfSearches(string city);

        Task<Forecast> FindForecastWeather(HistoryOfSearch historyOfSearch);
    }
}
