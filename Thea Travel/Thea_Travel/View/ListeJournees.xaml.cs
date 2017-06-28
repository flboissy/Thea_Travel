using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using Thea_Travel.Data;
using Thea_Travel.Data.Interface;
using Thea_Travel.View.CustomView;
using Thea_Travel.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View
{
    public partial class ListeJournees : ContentPage
    {

        FeuilleDeRouteViewModel CurrentFeuille { get; set; }
        AppManagerViewModel Manager { get; set; }
        public ListeJournees(AppManagerViewModel m)
        {
            Manager = m;
            CurrentFeuille = Manager.FeuillesVM.SelectedFeuille;
            BindingContext = CurrentFeuille;
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            Title = Manager.FeuillesVM.SelectedFeuille.Titre;
        }
        protected override void OnAppearing()
        {   
            base.OnAppearing();
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

            var action = await DisplayActionSheet("Que souhaitez vous faire ?", "Retour", null, AppManagerViewModel.CHOIX_MAP);
            if(action == AppManagerViewModel.CHOIX_MAP)
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

        private void listViewJournees_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listViewJournees.ItemTapped -= listViewJournees_ItemTapped;
            if(e.Item == null)
            {
                return;
            }
            CurrentFeuille.SelectedIndex = CurrentFeuille.LesJournéesVM.IndexOf(e.Item as JournéeViewModel);
            Navigation.PushAsync(new ListeProgrammes(Manager));
            listViewJournees.ItemTapped += listViewJournees_ItemTapped;
        }
    }
}
