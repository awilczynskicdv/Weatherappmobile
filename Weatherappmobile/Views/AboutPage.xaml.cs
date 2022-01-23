using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using Weatherappmobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weatherappmobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            string URL = "https://weatherappfn.azurewebsites.net/api/GetPreviousWeatherInfoTrigger";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", "QVxgZ4lzpkmc5x1AXCZOwdn3VadGSX6sRhzQEl7BhuDObdYJbi75pA==");
            var resultJson = await client.GetStringAsync(URL);
            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfoDbModel[]>(resultJson);
            pogoda.ItemsSource = weatherInfo;
        }
    }
}