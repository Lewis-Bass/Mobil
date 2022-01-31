using Mobil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        FavoritesViewModel viewModel = null;
        public FavoritesPage()
        {
            InitializeComponent();
            Title = "Favorite Searches";
            BindingContext = viewModel = new FavoritesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();            
            viewModel.OnAppearing();
        }

    }
}