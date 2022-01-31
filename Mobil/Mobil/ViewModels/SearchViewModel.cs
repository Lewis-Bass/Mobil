using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Mobil.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        #region properties

        public ObservableCollection<SearchCriteriaGUI> SearchCriterias { get; set; } = new ObservableCollection<SearchCriteriaGUI>();

        public Command LoadSearchCommand { get; }
        public Command AddNewCriteriaCommand { get; }
        public Command FindSearchCommand { get; }
        #endregion

        #region Constructor

        public SearchViewModel()
        {
            LoadSearchCommand = new Command(async () => await ExecuteLoadSearchCommand());
            AddNewCriteriaCommand = new Command(async () => await ExecuteAddNewCriteriaCommand());
            FindSearchCommand = new Command(async () => await ExecuteFindSearchCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
            ExecuteLoadSearchCommand();
        }

        #endregion

        #region Search Criteria

        /// <summary>
        /// loads all of the search criteria into the screen
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadSearchCommand()
        {
            IsBusy = true;

            try
            {
                if (SearchCriterias.Count <= 0)
                {
                    SearchCriterias.Clear();
                    SearchCriterias.Add(new SearchCriteriaGUI());
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

        #endregion

        #region Add Criteria

        /// <summary>
        /// adds a new entry into the search list. the entry is always added to the bottom of the screen
        /// </summary>
        /// <returns></returns>
        async Task ExecuteAddNewCriteriaCommand()
        {
            SearchCriterias.Add(new SearchCriteriaGUI());
        }
        #endregion

        #region Execute
        async Task ExecuteFindSearchCommand()
        {
            //SearchCriterias
            string searchString = string.Empty;
            XmlSerializer serializer = new XmlSerializer(SearchCriterias.ToArray().GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, SearchCriterias.ToArray());
                searchString = Uri.EscapeDataString( textWriter.ToString());
            }

            await Shell.Current.GoToAsync($"ResultsPage?SearchItem={string.Empty}&SearchQuery={searchString}");
        }
        #endregion
    }
}
