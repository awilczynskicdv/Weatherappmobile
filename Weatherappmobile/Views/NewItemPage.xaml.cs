using System;
using System.Collections.Generic;
using System.ComponentModel;
using Weatherappmobile.Models;
using Weatherappmobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weatherappmobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}