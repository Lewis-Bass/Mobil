using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobil.ViewModels
{
    public class ConnectViewModel : BaseViewModel
    {
        #region properties and globals
        public ConnectionInformation AddUpdateConnection { get; set; } = new ConnectionInformation();
        public ObservableCollection<ConnectionInformation> AllConnections { get; set; } = new ObservableCollection<ConnectionInformation>();


        //private ConnectionInformation originalConnection = null;

        #endregion

        #region constructor
        public ConnectViewModel()
        {
            Title = "Connect";
            AddUpdateLoginCommand = new Command(async () => await AddUpdateLogin());

            LoadAllConnectionsCommand = new Command(() => LoadAllConnections());
            ItemTapped = new Command<ConnectionInformation>(OnItemSelected);
            LoginCommand = new Command<ConnectionInformation>(OnItemSelected);
            DeleteCommand = new Command<ConnectionInformation>(OnDeleteSelected);
        }
        public void OnAppearing()
        {
            IsBusy = true;
            LoadAllConnections();
        }

        #endregion

        #region AllConnectionsTab

        public ICommand LoadAllConnectionsCommand { protected set; get; }
        public Command<ConnectionInformation> ItemTapped { get; protected set; }
        public Command<ConnectionInformation> LoginCommand { protected set; get; }
        public Command<ConnectionInformation> DeleteCommand { protected set; get; }

        public void LoadAllConnections()
        {
            IsBusy = true;

            try
            {
                AllConnections.Clear();
                SystemSettings.ReadSettings();
                foreach (var item in SystemSettings.GlobalSettings.AllConnnections.OrderBy(r => r.ConnectionName))
                {
                    AllConnections.Add(item);
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

        async void OnItemSelected(ConnectionInformation item)
        {
            if (item == null)
            {
                return;
            }

            await AttemptLogin(item);
        }

        async void OnDeleteSelected(ConnectionInformation item)
        {
            if (item == null)
            {
                return;
            }

            SystemSettings.DeleteConnectionSetting(item.ConnectionName);
            LoadAllConnections();
        }

        #endregion

        #region AddUpdate Tab

        public ICommand AddUpdateLoginCommand { protected set; get; }

        async Task AddUpdateLogin()
        {
            // validate all of the input fields
            if (string.IsNullOrWhiteSpace(AddUpdateConnection.ConnectionName)
                || string.IsNullOrWhiteSpace(AddUpdateConnection.IPAddress)
                || string.IsNullOrWhiteSpace(AddUpdateConnection.AccessKeyName)
                || string.IsNullOrWhiteSpace(AddUpdateConnection.Password))
            {
                AddUpdateConnection.LoginError = "All fields are required";
                return;
            }

            // write out the file
            SystemSettings.ReadSettings();
            //TODO: Check for dups before writing - move to AttemptLogin so that only valid logins are processed
            SystemSettings.GlobalSettings.AllConnnections.Add(AddUpdateConnection);
            SystemSettings.WriteSettings();

            await AttemptLogin(AddUpdateConnection);
        }

        #endregion

        //#region Swipe Command

        //public ICommand ItemSwipedCommand { protected set; get; }

        //#endregion

        #region Common Functions
        async Task AttemptLogin(ConnectionInformation connect)
        {
            // TODO: someday this will actually do a login to the site 
            // but for now just fake it
            App.CurrentConnectionInformation = connect;

            // if login is successful redirect...
            SystemSettings.ReadSettings();
            if (SystemSettings.GlobalSettings.Favorites.Any())
            {
                await Shell.Current.GoToAsync("//FavoritesPage");
            }
            else
            {
                await Shell.Current.GoToAsync("//SearchPage");
            }
        }

        #endregion

    }
}