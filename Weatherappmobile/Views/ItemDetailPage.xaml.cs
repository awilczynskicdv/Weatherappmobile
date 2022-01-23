using System.ComponentModel;
using Weatherappmobile.ViewModels;
using Xamarin.Forms;

namespace Weatherappmobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}