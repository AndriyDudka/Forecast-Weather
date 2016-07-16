using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ForecastWeatherApp.Models;

namespace ForecastWeatherApp.EntityContext
{
    public class WeatherContext: DbContext
    {   
        public WeatherContext(): base() 
        {
            Database.SetInitializer<WeatherContext>(new WeatherContextInitializer());
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<HistoryOfSearch> HistoryOfSearches { get; set; } 
    }
}