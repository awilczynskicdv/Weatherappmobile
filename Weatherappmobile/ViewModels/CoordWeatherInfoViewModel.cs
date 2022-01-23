using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using WeatherApp.Model;
using Weatherappmobile.Services;
using Xamarin.Forms;

namespace Weatherappmobile.ViewModels
{
    public class CoordWeatherInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ICoordWeatherInfo _rest = DependencyService.Get<ICoordWeatherInfo>();

        private Root coordweather;

        public Root CoordWeather
        {
            get { return coordweather; }
            set
            {
                coordweather = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CoordWeather"));
            }
        }

        public CoordWeatherInfoViewModel()
        {
            GetCoordWeather();
        }

        public async void GetCoordWeather()
        {
            var result = await _rest.getcoordweatherinfo(50, 50);
            CoordWeather = result;
        }
    }
}
