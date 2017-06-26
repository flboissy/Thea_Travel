using System;
using System.Collections.ObjectModel;
using System.Linq;
using Thea_Travel.Data;
using Thea_Travel.Manager;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View
{
    public partial class ListeFeuilleDeRoute : ContentPage
    {
        public ObservableCollection<IFeuilleDeRoute> Feuilles { get; set; }
        public AppManager Manager;
        private bool isPairRow = true;
        public ListeFeuilleDeRoute(AppManager m)
        {
            Manager = m;
            Feuilles = new ObservableCollection<IFeuilleDeRoute>(Manager.lesFeuilles.Feuilles.Where(elt => 
                                                                (elt.Voyageur.NomDeCompte == "|transphyto\\" + Authenticator.getAuthenticator().Username)
                                                                &&
                                                                (elt.Fin.CompareTo(DateTime.Today) > 0)
                                                                ));
            BindingContext = this;
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetBackButtonTitle(this, "Feuille(s) de route");
        }
        private async void Selectionner_Feuille_De_Route(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            IFeuilleDeRoute fdr = e.SelectedItem as IFeuilleDeRoute;
            await Navigation.PushAsync(new ListeJournees(fdr),true);
            
            listViewFeuilles.SelectedItem = null;
        }
        private void CellViewFeuilleDeRoute_Appearing(object sender, EventArgs e)
        {
            var viewCell = sender as ViewCell;
            if (isPairRow)
            {
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("#c7dae0");
                }
            }
            else
            {
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("#ffffff");
                }
            }
            isPairRow = !isPairRow;
        }
        private async void LogoThea_Tapped(object sender, EventArgs e)
        {
            
        }
    }
}
