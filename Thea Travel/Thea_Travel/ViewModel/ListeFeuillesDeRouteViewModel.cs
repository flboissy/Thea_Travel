using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVMToolkit;
using System.Collections.ObjectModel;
using Thea_Travel.Data;
using Thea_Travel.Manager.DataManager;

namespace Thea_Travel.ViewModel
{
    public class ListeFeuillesDeRouteViewModel : BaseViewModel<ListeFeuillesDeRoute>
    {
        public ObservableCollection<FeuilleDeRouteViewModel> LesFeuillesVM { get { return lesFeuillesVM; } }
        private ObservableCollection<FeuilleDeRouteViewModel> lesFeuillesVM = new ObservableCollection<FeuilleDeRouteViewModel>();
        public ObservableCollection<FeuilleDeRouteViewModel> UserFeuillesVM { get { return userFeuillesVM; } }
        private ObservableCollection<FeuilleDeRouteViewModel> userFeuillesVM;


        public ListeFeuillesDeRouteViewModel(ListeFeuillesDeRoute lesFeuilles)
        {
            Model = lesFeuilles;
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                SetProperty(ref selectedIndex, value);
                OnPropertyChanged(nameof(SelectedFeuille));
            }
        }
        private int selectedIndex = -1;

        public FeuilleDeRouteViewModel SelectedFeuille
        {
            get
            {
                return (selectedIndex != -1) ? UserFeuillesVM[SelectedIndex] : null;
            }
        }

        async public Task initFeuillesDeRoute(IDataManager manager)
        {
            await Model.initFeuillesDeRoute(manager);
            foreach (var f in Model.Feuilles)
            {
                lesFeuillesVM.Add(new FeuilleDeRouteViewModel(f));
            }
            userFeuillesVM = new ObservableCollection<FeuilleDeRouteViewModel>(LesFeuillesVM.Where(elt =>
                                                        (elt.VoyageurVM.NomDeCompte == "|transphyto\\" + Authenticator.getAuthenticator().Username)
                                                        &&
                                                        (elt.Fin.CompareTo(DateTime.Today) > 0)
                                                         ));
        }
    }
}
