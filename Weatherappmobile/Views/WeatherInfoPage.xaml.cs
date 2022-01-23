using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weatherappmobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherInfoPage : ContentPage
    {
        public WeatherInfoPage()
        {
            InitializeComponent();
        }

        private async void GoToHistoryBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
    }
}