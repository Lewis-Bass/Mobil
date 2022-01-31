using Mobil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFilesPage : ContentPage
    {

        AddFileViewModel viewModel;

        public AddFilesPage()
        {
            InitializeComponent();
            Title = "Add Files";
            BindingContext = viewModel = new AddFileViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickMultipleAsync();
                if (result != null)
                {
                    var f = result.Select(r => new Models.FileListing
                    {
                        DocumentName = r.FileName,
                        PathName = r.FullPath,
                    }).ToList();
                    FileCollection.ItemsSource = f;
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}