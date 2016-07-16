using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ForecastWeatherApp.Models;

namespace ForecastWeatherApp.EntityContext
{
    public class WeatherContextInitializer:DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            var c1 = new City
            {
                Name = "Kiev"
            };
            context.Cities.Add(c1);

            c1 = new City
            {
                Name = "Lviv"
            };
            context.Cities.Add(c1);

            c1 = new City
            {
                Name = "Kharkiv"
            };
            context.Cities.Add(c1);

            c1 = new City
            {
                Name = "Dnipropetrovsk"
            };
            context.Cities.Add(c1);

            c1 = new City
            {
                Name = "Odessa"
            };
            context.Cities.Add(c1);

            context.SaveChanges();
        }
    }
}