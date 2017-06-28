using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Services;
using Thea_Travel.ViewModel;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    class Hôtel : Hebergement
    {
       
        public string Tel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Hôtel(string nom, string tel, string adresse, DateTime checkIn, DateTime checkOut)
        {
            Nom = nom;
            Tel = tel;
            Adresse = adresse;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public async override Task ActionSheet()
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Que souhaitez vous faire ?", "Retour", null, AppManagerViewModel.CHOIX_APPELER,AppManagerViewModel.CHOIX_MAP);

            if (result.Equals(AppManagerViewModel.CHOIX_APPELER))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(Tel.Trim());
                }
            }
            else if (result.Equals(AppManagerViewModel.CHOIX_MAP))
            {
                switch (Device.OS)
                {
                    case TargetPlatform.iOS:
                        Device.OpenUri(new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(Adresse))));
                        break;
                    case TargetPlatform.Android:
                        Device.OpenUri(new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(Adresse))));
                        break;
                }
            }
        }
    }
}
