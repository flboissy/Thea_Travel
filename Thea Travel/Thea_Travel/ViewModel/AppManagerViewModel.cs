using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVMToolkit;
using System.Collections.ObjectModel;
using Thea_Travel.Manager;
using Thea_Travel.Manager.DataManager;

namespace Thea_Travel.ViewModel
{
    public class AppManagerViewModel : BaseViewModel<AppManager>
    {

        public static readonly string CHOIX_APPELER = "Appeler";
        public static readonly string CHOIX_MAP = "Itinéraire";
        public static readonly string IS_PAIR_KEY = "PairKey";
        public AppManagerViewModel(IDataManager dataManager)
        {
            Model = new AppManager(dataManager);
            FeuillesVM = new ListeFeuillesDeRouteViewModel(Model.LaListe);
        }

        public ListeFeuillesDeRouteViewModel FeuillesVM
        {
            get { return feuillesVM; }
            set { SetProperty(ref feuillesVM, value); }
        }
        private ListeFeuillesDeRouteViewModel feuillesVM;

        async public Task initFeuillesDeRoute()
        {
            await FeuillesVM.initFeuillesDeRoute(Model.DataManager);
        }

    }
}
