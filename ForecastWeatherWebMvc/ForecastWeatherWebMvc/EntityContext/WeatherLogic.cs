using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForecastWeatherApp.Models;
using Microsoft.Ajax.Utilities;

namespace ForecastWeatherApp.EntityContext
{
    public class WeatherLogic
    {
        private  WeatherContext weatherContext;

        public WeatherLogic(WeatherContext wc)
        {
            weatherContext = wc;
        }

        public  bool FindCity(City city)
        {
            foreach (var p in weatherContext.Cities)
            {
                if (p.Name == city.Name) return true;
            }
            return false;
        }

        public  City SomeMethod(string name)
        {
            foreach (var p in weatherContext.Cities)
            {
                if (p.Name == name) return p;
            }
            return null;
        }

        public void DeleteCity(string name)
        {
            var p = weatherContext.Cities.SingleOrDefault(x => x.Name == name);

            if (p != null)
            {
                weatherContext.Cities.Remove(p);
                weatherContext.SaveChanges();
            }
        }
    }
}