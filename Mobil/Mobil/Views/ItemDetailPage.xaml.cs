using Mobil.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Mobil.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}