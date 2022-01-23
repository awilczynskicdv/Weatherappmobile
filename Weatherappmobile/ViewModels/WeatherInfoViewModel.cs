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
    public class WeatherInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IWeatherInfo _rest = DependencyService.Get<IWeatherInfo>();

        private Root weather;

        public Root Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Weather"));
            }
        }


        public WeatherInfoViewModel()
        {
            GetWeather();
        }

        public async void GetWeather()
        {
            var result = await _rest.getweatherinfo("Warsaw");
            Weather = result;
        }
    }
}
