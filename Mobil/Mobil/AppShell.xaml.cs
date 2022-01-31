using Mobil.ViewModels;
using Mobil.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mobil
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute("FavoritesAddPage", typeof(FavoritesAddPage));
            Routing.RegisterRoute("ResultsPage", typeof(ResultsPage));

        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
