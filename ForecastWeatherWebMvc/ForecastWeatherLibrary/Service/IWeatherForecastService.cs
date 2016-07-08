using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastWeatherLibrary.DTO;

namespace ForecastWeatherLibrary.Service
{
    public interface IWeatherForecastService
    {
        Forecast GetForecast(string city, int days);
    }
}
