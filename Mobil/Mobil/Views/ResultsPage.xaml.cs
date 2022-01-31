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
    //[QueryProperty(nameof(SearchItem), nameof(SearchItem))]
    public partial class ResultsPage : ContentPage
    {
       
        ResultsViewModel viewModel = null;

        public ResultsPage()
        {
            InitializeComponent();
            Title = "Results";
            BindingContext = viewModel = new ResultsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }


    }
}