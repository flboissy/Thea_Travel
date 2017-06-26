using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thea_Travel.Ressources;
using Thea_Travel.Services;
using Thea_Travel.View;
using Xamarin.Forms;

namespace Thea_Travel
{
    public partial class App : Application
    {
        public static readonly string AppName = "TheaTravel";
        public App()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                AppResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
            InitializeComponent();
            var mainPage = new MainPage();
            var rootPage = new NavigationPage(mainPage);
            MainPage = rootPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
