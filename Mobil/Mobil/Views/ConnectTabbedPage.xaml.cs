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
    public partial class ConnectTabbedPage : TabbedPage
    {
        ConnectViewModel _viewModel;

        public ConnectTabbedPage()
        {
            InitializeComponent();
            Title = "Connections";

            BindingContext = _viewModel = new ConnectViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            if (!_viewModel.AllConnections.Any())
            {
                CurrentPage = Children[1];
                //var pages = Children.GetEnumerator();
                //pages.MoveNext(); // First page    
            }
            
        }

    }
}