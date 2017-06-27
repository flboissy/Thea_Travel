using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using Thea_Travel.Data;
using Thea_Travel.Data.Interface;
using Thea_Travel.View.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View
{
    public partial class ListeJournees : ContentPage
    {
        private IFeuilleDeRoute Feuille { get; set; }
        public ObservableCollection<JournéeViewModel> Journées { get; set; }
        public ObservableCollection<IAdresseUtile> Adresses { get; set; }
        public ListeJournees(IFeuilleDeRoute f)
        {           
            Feuille = f;
            Journées = new ObservableCollection<JournéeViewModel>(Feuille.Journées.Select(elt => new JournéeViewModel(Feuille.Journées.IndexOf(elt),elt))) ;
            Adresses = new ObservableCollection<IAdresseUtile>(Feuille.Adresses.Adresses);
            BindingContext = this;
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            Title = f.Titre;
        }
        protected override void OnAppearing()
        {   
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (e.SelectedItem == null)
            {
                return;
            }

            JournéeViewModel j = e.SelectedItem as JournéeViewModel;
            await Navigation.PushAsync(new ListeProgrammes(j.Model));
            listViewJournees.SelectedItem = null;
        }

        private void CellViewJournées_Appearing(object sender, EventArgs e)
        {           
            CellViewJournées viewCell = sender as CellViewJournées;  
            if(viewCell.IndexCell % 2 == 0 )
            {
                viewCell.View.BackgroundColor = Color.FromHex("#c7dae0");
            }
        }

        private async void listViewAddresses_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var addr = e.SelectedItem as AdresseUtile;
            if(addr == null)
            {
                return;
            }

            var action = await DisplayActionSheet("Que souhaitez vous faire ?", "Retour", null, ListeProgrammes.CHOIX_MAP);
            if(action == ListeProgrammes.CHOIX_MAP)
            {
                switch (Device.OS)
                {
                    case TargetPlatform.iOS:
                        Device.OpenUri(new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(addr.Adresse))));
                        break;
                    case TargetPlatform.Android:
                        Device.OpenUri(new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(addr.Adresse))));
                        break;
                }
            }
            listViewAddresses.SelectedItem = null;
        }
    }
}
