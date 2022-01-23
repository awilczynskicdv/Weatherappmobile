using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace Weatherappmobile.Services
{
    public interface IWeatherInfo
    {
        Task<Root> getweatherinfo(string city, double optionalLon, double optionalLat);
    }
}
