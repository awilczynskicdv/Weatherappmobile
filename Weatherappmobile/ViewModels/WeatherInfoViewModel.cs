using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
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

        public ICommand ButtonCommand { get; private set; }

        private string cityName;
        public string CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;
                OnPropertyChanged();
            }
        }

        public Root Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                OnPropertyChanged();
            }
        }


        public WeatherInfoViewModel()
        {
            ButtonCommand = new Command(() => {
                GetWeather(cityName);
            });
        }

        public async void GetWeather(string city)
        { 
            var result = await _rest.getweatherinfo(city, 0, 0);
            Weather = result;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
