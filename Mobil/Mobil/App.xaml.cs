using Mobil.Models;
using Mobil.Services;
using Mobil.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil
{
    public partial class App : Application
    {
        /// <summary>
        ///  Currently the system is connected to this ark
        /// </summary>
        public static ConnectionInformation CurrentConnectionInformation { get; set; }
               
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
