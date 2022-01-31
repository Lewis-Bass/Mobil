using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.Views
{
    public partial class ConnectPage : ContentPage
    {
        public ConnectPage()
        {
            InitializeComponent();
        }

        async void LoginButtonClicked(object sender, EventArgs args)
        {           
            await Shell.Current.GoToAsync("//SearchPage");
        }
    }
}