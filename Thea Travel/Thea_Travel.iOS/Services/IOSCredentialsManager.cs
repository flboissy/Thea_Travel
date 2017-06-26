using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Thea_Travel.Services;
using Thea_Travel.iOS.Services;

[assembly: Dependency(typeof(IOSCredentialsManager))]
namespace Thea_Travel.iOS.Services
{
    class IOSCredentialsManager : ICredentialsManager
    {
        private static readonly string ACCOUNT_INFORMATION = "UserAccount";
        public string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        public string UserName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
            }
        }

        public void SaveCredentials(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                Account account = new Account
                {
                    Username = username
                };
                account.Properties.Add("Password", password);
                AccountStore.Create().Save(account, App.AppName);
            }
        }
    }
}
