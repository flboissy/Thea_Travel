using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;
using Thea_Travel.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View
{
    public partial class JournéesCarouselView : ContentPage
    {
        AppManagerViewModel Manager { get; set; }
        FeuilleDeRouteViewModel CurrentFeuille { get; set; }


        public JournéesCarouselView(AppManagerViewModel m)
        {
            Manager = m;
            CurrentFeuille = Manager.FeuillesVM.SelectedFeuille;
            CurrentFeuille.SelectedIndex = 0;
            BindingContext = CurrentFeuille;
            InitializeComponent();
        }

        private void CarouselView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            CurrentFeuille.SelectedIndex = CurrentFeuille.LesJournéesVM.IndexOf(e.SelectedItem as JournéeViewModel);
        }

        private void listViewProgrammes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            CurrentFeuille.SelectedJournée.SelectedIndex = CurrentFeuille.SelectedJournée.LesProgrammesVM.IndexOf(e.SelectedItem as ProgrammeViewModel);
            var lv = sender as ListView;
            lv.SelectedItem = null;
        }
    }
}
