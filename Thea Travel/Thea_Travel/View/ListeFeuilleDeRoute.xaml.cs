using System;
using System.Collections.ObjectModel;
using System.Linq;
using Thea_Travel.Data;
using Thea_Travel.Manager;
using Thea_Travel.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View
{
    public partial class ListeFeuilleDeRoute : ContentPage
    {
        public AppManagerViewModel Manager;
        private bool isPairRow = true;
        public ListeFeuilleDeRoute(AppManagerViewModel m)
        {
            Manager = m;
            BindingContext = Manager;
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
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

        private async void listViewFeuilles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listViewFeuilles.ItemTapped -= listViewFeuilles_ItemTapped;
            Manager.FeuillesVM.SelectedIndex = Manager.FeuillesVM.UserFeuillesVM.IndexOf(e.Item as FeuilleDeRouteViewModel);
            await Navigation.PushAsync(new JournéesCarouselView(Manager));
            listViewFeuilles.ItemTapped += listViewFeuilles_ItemTapped;
        }
    }
}
