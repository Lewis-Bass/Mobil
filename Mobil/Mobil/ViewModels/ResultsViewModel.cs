using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobil.ViewModels
{
    [QueryProperty(nameof(SearchItem), nameof(SearchItem))]
    [QueryProperty(nameof(SearchQuery), nameof(SearchQuery))]
    public class ResultsViewModel : BaseViewModel
    {
        #region Search Item passed in query string
        string searchItem = string.Empty;
        public string SearchItem
        {
            get
            {
                return searchItem;
            }
            set
            {
                searchItem = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
            }
        }

        string searchQuery = string.Empty;
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                searchQuery = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
            }
        }

        #endregion

        public ObservableCollection<SearchResults> ResultsList { get; set; } 
            = new ObservableCollection<SearchResults>();

        public ICommand LoadSearchResultsCommand { protected set; get; }

        public ResultsViewModel()
        {
            LoadSearchResultsCommand = new Command(() => ExecuteLoadSearchResultsCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
            ExecuteLoadSearchResultsCommand();
        }


        /// <summary>
        /// loads all of the search criteria into the screen
        /// </summary>
        /// <returns></returns>
        //async Task ExecuteLoadSearchResultsCommand()
        public void ExecuteLoadSearchResultsCommand()
        {
            IsBusy = true;

            try
            {
                ResultsList.Clear();
                // TODO: Really connect to the ark to get the data

                string si = string.IsNullOrWhiteSpace(SearchItem) ? "Search" : SearchItem;
                for (int i = 1; i <= 10; i++)
                {
                    SearchResults result = new SearchResults
                    {
                        DocumentDate = DateTime.Now.AddDays(0 - i).ToShortDateString(),
                        DocumentName = $"Document-{i}",
                        PathName = $"MyDocuments/{si}/Document-{i}"

                    };
                    ResultsList.Add(result);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        //private void GetSearchData()
        //{
        //    ResultsList.Clear();
        //    for (int i = 1; i<=10; i++)
        //    {
        //        SearchResults result = new SearchResults
        //        {
        //            DocumentDate = DateTime.Now.AddDays(0 - i).ToShortDateString(),
        //            DocumentName = $"Document-{i}",
        //            //PathName = $"MyDocuments/{SearchItem}/Document-{i}"

        //        };
        //        ResultsList.Add(result);
        //    }
        //}
    }

   
}
