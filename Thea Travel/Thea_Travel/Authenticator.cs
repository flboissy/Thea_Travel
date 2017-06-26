
using Xamarin.Forms;
using System.Net.Http;
using System;
using System.Net;
using Thea_Travel.Manager;
using System.Threading.Tasks;
using Xamarin.Auth;
using Thea_Travel.Services;

namespace Thea_Travel
{
    public class Authenticator : BindableObject
    {
        public static readonly string PREF_AUTH_KEY = "AuthSaved";
        private HttpClientHandler handler;
        private HttpClient client;
        private static Authenticator authenticator;
        private IPreferences Prefs;
        private ICredentialsManager CredManager;

        public string Username
        {
            get
            {
                if(mUsername == null)
                {
                    return String.Empty;
                }
                return mUsername;
            }

            set
            {
                mUsername = value;
                OnPropertyChanged("Username");
            }
        }
        private string mUsername;

        public string Password
        {
            get
            {
                if(mPassword == null)
                {
                    return String.Empty;
                }
                return mPassword;
            }
            set
            {
                mPassword = value;
                OnPropertyChanged("Password");
            }
        }
        private string mPassword;

        public bool DoesSaveInformation
        {
            get
            {
                return Prefs.getBoolPreferencesForKey(PREF_AUTH_KEY);
            }
            set
            {
                Prefs.BoolPreferences(value, PREF_AUTH_KEY);
                OnPropertyChanged("DoesSaveInformation");
            }
        }

        public static Authenticator getAuthenticator()
        {
            if (authenticator == null)
            {
                authenticator = new Authenticator();
            }
            return authenticator;
        }

        private Authenticator()
        {
            Prefs = DependencyService.Get<IPreferences>();
            CredManager = DependencyService.Get<ICredentialsManager>();
        }
        public async Task signIn()
        {
            handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(Username, Password);
            HttpResponseMessage response;
            client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(8);
            client.BaseAddress = new Uri(HttpHelper.restBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
            try
            {
                response = await client.GetAsync(HttpHelper.lists);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException("Request fail", response.StatusCode);
                }
            }
            catch (TaskCanceledException)
            {
                throw new HttpException("Tiemout", HttpStatusCode.RequestTimeout);
            }
        }

        public void ManageAuthSave()
        {
            if (DoesSaveInformation)
            {
                CredManager.SaveCredentials(Username, Password);
            }
        }

        public void SetSavedCred()
        {
            Username = CredManager.UserName;
            Password = CredManager.Password;
        }

        public bool CheckOfflineAuth()
        {
            return !Username.Equals(CredManager.UserName) || !Password.Equals(CredManager.Password);
        }

        public void Disconnect()
        {
            Username = String.Empty;
            Password = String.Empty;
            DoesSaveInformation = false;
        }
    }
}
