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

        private async void GoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherInfoPage());
        }
    }
}