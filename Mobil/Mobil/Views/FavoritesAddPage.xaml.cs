using Mobil.Models;
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
    public partial class FavoritesAddPage : ContentPage
    {
        FavoritesAddViewModel viewModel;
        public FavoritesAddPage()
        {
            InitializeComponent();
            Title = "Favorite Searches";
            BindingContext = viewModel = new FavoritesAddViewModel();
        }
                
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        /// <summary>
        /// cant access the selecteditems from the view model?
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            List<Binder> binders = new List<Binder>();
            foreach(var item in FavoriteListView.SelectedItems)
            {
                System.Diagnostics.Debug.WriteLine(item);
                Binder b = item as Binder;
                binders.Add(b);
            }
          
            viewModel.ExecuteAddToFavoritesCommand(binders.ToArray());
        }

        
    }
}