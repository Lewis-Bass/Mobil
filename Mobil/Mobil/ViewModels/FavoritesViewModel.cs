using Mobil.Models;
using Mobil.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobil.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<Favorite> Favorites { get; set; } = new ObservableCollection<Favorite>();
        public string SearchFavorite { get; set; } = string.Empty;
        public ICommand LoadFavoritesCommand { get; protected set; }
        public ICommand AddFavoritesCommand { get; protected set; }
        public Command<Favorite> ItemTapped { get; protected set; }
        public Command<Favorite> DeleteCommand { get; protected set; }
        public FavoritesViewModel()
        {
            LoadFavoritesCommand = new Command(() => LoadFavorites());
            AddFavoritesCommand = new Command(async () => await ExecuteAddFavoritesCommand());
            DeleteCommand = new Command<Favorite>(ExecuteDeleteCommand);            
            ItemTapped = new Command<Favorite>(ExecuteItemTapped);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            LoadFavorites();
        }

        public async void LoadFavorites()
        {
            try
            {
                Favorites.Clear();
                SystemSettings.ReadSettings();
                foreach (var f in SystemSettings.GlobalSettings.Favorites.OrderBy(r => r.FavoriteName))
                {
                    Favorites.Add(f);
                }
                if (!Favorites.Any())
                {
                    await ExecuteAddFavoritesCommand();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void ExecuteItemTapped(Favorite item)
        {
            if (item == null)
            {
                return;
            }

            // go to view results
            await Shell.Current.GoToAsync($"ResultsPage?SearchItem={item.FavoriteName}");
        }

        async Task ExecuteAddFavoritesCommand()
        {
            await Shell.Current.GoToAsync("FavoritesAddPage"); // relative path shows back button        
        }

        async void ExecuteDeleteCommand(Favorite item)
        {
            if (item == null)
            {
                return;
            }
            SystemSettings.DeleteFavorite(item);
            Favorites.Remove(item);
        }
    }
}
