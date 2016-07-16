using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForecastWeatherLibrary.DTO;

namespace ForecastWeatherApp.Models
{
    public class HistoryOfSearch
    {
        public int Id { get; set; }

        public string Json { get; set; }

        public DateTime Date { get; set; }      
    }
}