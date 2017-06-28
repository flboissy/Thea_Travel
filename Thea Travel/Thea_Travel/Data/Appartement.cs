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
    class Appartement : Hebergement
    {
        public Appartement(string nom, string adresse)
        {
            Nom = nom;
            Adresse = adresse;
        }

        public async override Task ActionSheet()
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Que souhaitez vous faire ?", "Retour", null, AppManagerViewModel.CHOIX_MAP);

            if (result.Equals(AppManagerViewModel.CHOIX_MAP))
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
