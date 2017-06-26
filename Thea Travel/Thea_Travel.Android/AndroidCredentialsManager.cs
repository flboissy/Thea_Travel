using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Thea_Travel.Services;
using Thea_Travel.Droid;

[assembly: Dependency(typeof(AndroidCredentialsManager))]
namespace Thea_Travel.Droid
{
    class AndroidCredentialsManager : ICredentialsManager
    {
        public string Password
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        public string UserName
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public void DeleteCredentials()
        {
            var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create(Forms.Context).Delete(account, App.AppName);
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
                AccountStore.Create(Forms.Context).Save(account, App.AppName);
            }
        }
    }
}