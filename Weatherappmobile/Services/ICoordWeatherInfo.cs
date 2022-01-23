using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace Weatherappmobile.Services
{
    public interface ICoordWeatherInfo
    {
        Task<Root> getcoordweatherinfo(double Lon, double Lat);
    }
}
