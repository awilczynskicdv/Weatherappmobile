using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using WeatherApp.Model;
using Weatherappmobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weatherappmobile.ViewModels
{
    public class WeatherInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IWeatherInfo _rest = DependencyService.Get<IWeatherInfo>();

        private Root weather;

        public ICommand ButtonCommand { get; private set; }
        public ICommand ButtonCommandLocation { get; private set; }

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
                GetWeather(cityName, 0, 0);
            });
            ButtonCommandLocation = new Command(async () => {
                CancellationTokenSource cts;
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                GetWeather("", location.Longitude, location.Latitude);
            });
        }

        public async void GetWeather(string city, double lon, double lat)
        { 
            var result = await _rest.getweatherinfo(city, lon, lat);
            Weather = result;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
