using Mobil.Models;
using Mobil.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobil.ViewModels
{
    public class FavoritesAddViewModel : BaseViewModel
    {
        public string SearchFavorite { get; set; } = string.Empty;
        public ObservableCollection<Binder> BinderSearchResults { get; set; } = new ObservableCollection<Binder>();

        public ICommand SearchBindersCommand { get; private set; }
        
        public ICommand BinderSelectionChanged { get; private set; }
        public FavoritesAddViewModel()
        {
            SearchBindersCommand = new Command(async () => await ExecuteSearchBindersCommand());
        }

        public void OnAppearing()
        {
            IsBusy = false;
        }

        async Task ExecuteSearchBindersCommand()
        {
            var binderService = new BinderService();
            var binderList = await binderService.SearchBinders(SearchFavorite);
            BinderSearchResults.Clear();
            foreach (var b in binderList.OrderBy(r => r.BinderName))
            {
                BinderSearchResults.Add(b);
            }

        }

        public void ExecuteAddToFavoritesCommand(Binder[] binders)
        {
            SystemSettings.AddFavorites(binders);
        }

    }
}
