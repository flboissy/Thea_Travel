using System;
using System.Collections.ObjectModel;
using System.Linq;
using Thea_Travel.Data;
using Thea_Travel.View.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View
{
    public partial class ListeJournees : ContentPage
    {
        private IFeuilleDeRoute Feuille { get; set; }
        public ObservableCollection<JournéeViewModel> Journées { get; set; }
        public ListeJournees(IFeuilleDeRoute f)
        {           
            Feuille = f;
            Journées = new ObservableCollection<JournéeViewModel>(Feuille.Journées.Select(elt => new JournéeViewModel(Feuille.Journées.IndexOf(elt),elt))) ;  
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
            await Navigation.PushModalAsync(new ListeProgrammes(j.Model));
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
    }
}
