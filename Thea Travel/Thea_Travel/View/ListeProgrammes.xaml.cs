using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using Thea_Travel.Data;
using Thea_Travel.Services;
using Thea_Travel.ViewModel;
using Xamarin.Forms;

namespace Thea_Travel.View
{
    public partial class ListeProgrammes : ContentPage
    {


        AppManagerViewModel Manager { get; set; }

        JournéeViewModel CurrentJournée { get; set; }
        public ListeProgrammes(AppManagerViewModel m)
        {
            Manager = m;
            CurrentJournée = Manager.FeuillesVM.SelectedFeuille.SelectedJournée;

            BindingContext = CurrentJournée;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            Title = "Journée du " + String.Format("{0:d}", CurrentJournée.DateDuJour);

            if (!App.Current.Properties.ContainsKey(AppManagerViewModel.IS_PAIR_KEY))
            {
                App.Current.Properties.Add(AppManagerViewModel.IS_PAIR_KEY, true);
            }
            else
            {
                App.Current.Properties[AppManagerViewModel.IS_PAIR_KEY] = true;
            }
        }

    }
}
