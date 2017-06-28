using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVMToolkit;
using System.Collections.ObjectModel;
using Thea_Travel.Data;

namespace Thea_Travel.ViewModel
{
    public class FeuilleDeRouteViewModel : BaseViewModel<IFeuilleDeRoute>
    {
        public FeuilleDeRouteViewModel(IFeuilleDeRoute fdr)
        {
            Model = fdr;
            VoyageurVM = new VoyageurViewModel(Model.Voyageur);
            AdressesVM = new ListeAdresseUtilesViewModel(Model.Adresses);
            foreach(var f in Model.Journées)
            {
                lesJournéesVM.Add(new JournéeViewModel(Model.Journées.IndexOf(f), f));
            }
        }

        public ListeAdresseUtilesViewModel AdressesVM { get; }

        public VoyageurViewModel VoyageurVM;
        public ObservableCollection<JournéeViewModel> LesJournéesVM { get { return lesJournéesVM; } }
        private ObservableCollection<JournéeViewModel> lesJournéesVM = new ObservableCollection<JournéeViewModel>();

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                SetProperty(ref selectedIndex, value);
                OnPropertyChanged(nameof(SelectedJournée));
            }
        }
        private int selectedIndex = -1;

        public JournéeViewModel SelectedJournée
        {
            get
            {
                return (selectedIndex != -1) ? LesJournéesVM[SelectedIndex] : null;
            }
        }

        public DateTime Debut
        {
            get { return Model.Debut; }
            set { SetProperty(Model.Debut, value, () => Model.Debut = value); }
        }
        public DateTime Fin
        {
            get { return Model.Fin; }
            set { SetProperty(Model.Fin, value, () => Model.Fin = value); }
        }

        public string ID
        {
            get { return Model.ID; }
            set { SetProperty(Model.ID, value, () => Model.ID = value); }
        }
        public string Titre
        {
            get { return Model.Titre; }
            set { SetProperty(Model.Titre, value, () => Model.Titre = value); }
        }

        

    }
}
