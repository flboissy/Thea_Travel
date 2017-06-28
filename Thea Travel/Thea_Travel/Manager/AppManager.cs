using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thea_Travel.Data;
using Thea_Travel.Manager.DataManager;

namespace Thea_Travel.Manager
{
    public class AppManager
    {
        public IDataManager DataManager { get; set; }
        private bool isSynchronized = false;
        public ListeFeuillesDeRoute LaListe { get; set; }
        public AppManager(IDataManager dataManager)
        {
            DataManager = dataManager;
            LaListe = new ListeFeuillesDeRoute();
        }
        async public Task initFeuillesDeRoute()
        {
            if (!isSynchronized)
            {
                await LaListe.initFeuillesDeRoute(DataManager);
                isSynchronized = true;
            }
        }
    }
}