using System;
using Thea_Travel.Manager;
using Thea_Travel.Services;
using Thea_Travel.ViewModel;
using Xamarin.Forms;

namespace Thea_Travel.View
{
    public partial class MenuPrincipal : ContentPage
    {
        AppManagerViewModel Manager;
        IPreferences Prefs;
        ICredentialsManager CredManager;
        public MenuPrincipal(AppManagerViewModel manager)
        {
            Manager = manager;
            Prefs = DependencyService.Get<IPreferences>();
            CredManager = DependencyService.Get<ICredentialsManager>();
            InitializeComponent();
            Title = "Théa Travel Tools";
        }

        private async void Button_Feuille_De_Route_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            await Navigation.PushAsync(new ListeFeuilleDeRoute(Manager),true);
            (sender as Button).IsEnabled = true;
        }

        private void Button_Adresse_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
        }

        private void  Button_Infos_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
        }

        private async void Button_Deconnection_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Authenticator.getAuthenticator().Disconnect();
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync(true);
            (sender as Button).IsEnabled = true;
        }
    }
}
