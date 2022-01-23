using System;
using Weatherappmobile.Services;
using Weatherappmobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weatherappmobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IWeatherInfo, WeatherInfo>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
