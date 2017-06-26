using System;
using System.Net.Http;
using Thea_Travel.Manager;
using Xamarin.Forms;
using System.IO;
using Thea_Travel.Manager.DataManager;
using System.Threading.Tasks;
using System.Net;
using Thea_Travel.Ressources;

namespace Thea_Travel.View
{
    public partial class MainPage : ContentPage
    {
        private Authenticator myAuthenticator;
        private AppManager Manager;
        public MainPage()
        {
            myAuthenticator = Authenticator.getAuthenticator();
            InitializeComponent();
            if (myAuthenticator.DoesSaveInformation)
            {
                AutoSignIn();
            }
            BindingContext = myAuthenticator;
        }
        private async void Sign_In_Clicked(object sender, EventArgs e)
        {
            SignInButton.IsEnabled = false;
            UserName.IsEnabled = false;
            Password.IsEnabled = false;
            try
            {
                await myAuthenticator.signIn();
                myAuthenticator.ManageAuthSave();
                await NavigateToMenu(new HttpDataManager());
            }
            catch (HttpException ex)
            {
                await CheckForRequestStatus(ex.Status);
            }
            catch (HttpRequestException)
            {
                await ManageHttpRequestException();
            }
            finally
            {
                SignInButton.IsEnabled = true;
                UserName.IsEnabled = true;
                Password.IsEnabled = true;
            }
        }

        private async void AutoSignIn()
        {
            myAuthenticator.SetSavedCred();
            try
            {
                await myAuthenticator.signIn();
                await NavigateToMenu(new HttpDataManager());

            }
            catch (HttpRequestException)
            {
                await ManageHttpRequestException();
            }
        }
        private async Task NavigateToMenu(IDataManager m)
        {
            Manager = new AppManager(m);
            await Manager.initFeuillesDeRoute();
            Navigation.InsertPageBefore(new MenuPrincipal(Manager), this);
            await Navigation.PopAsync(true);
        }

        private async Task CheckForRequestStatus(HttpStatusCode status)
        {
            if (status == HttpStatusCode.RequestTimeout)
            {
                await DisplayAlert(AppResources.ReqTimeOutTitle, AppResources.ReqTimeOutText, AppResources.ReqTimeOutButton);
            }
            else
            {
                await DisplayAlert(AppResources.IdIncoTitle, AppResources.IdIncoText, AppResources.IdIncoButton);
            }
        }
        
        private async Task ManageHttpRequestException()
        {
            var answer = await DisplayAlert(AppResources.NoCoTitle, AppResources.NoCoText, AppResources.NoCoFirstButton, AppResources.NoCoSecondButton);
            if (answer)
            {
                if (myAuthenticator.CheckOfflineAuth())
                {
                    await DisplayAlert(AppResources.IdIncoOffTitle, AppResources.IdIncoOffText, AppResources.IdIncoOffButton);
                    return;
                }
                try
                {
                    await NavigateToMenu(new OfflineDataManager());
                }
                catch (FileNotFoundException)
                {
                    await DisplayAlert(AppResources.NoSyncTitle, AppResources.NoSyncText, AppResources.NoSyncButton);
                }
            }
        }
    }
}
