using System.Threading.Tasks;
using Thea_Travel.Data;
using Thea_Travel.Manager.DataManager;

namespace Thea_Travel.Manager
{
    public class AppManager
    {
        IDataManager DataManager { get; set; }
        private bool isSynchronized = false;
        public ListeFeuillesDeRoute lesFeuilles { get; set; }
        public AppManager(IDataManager dataManager)
        {
            DataManager = dataManager;
            lesFeuilles = new ListeFeuillesDeRoute();
        }
        async public Task initFeuillesDeRoute()
        {
            if (!isSynchronized)
            {
                await lesFeuilles.initFeuillesDeRoute(DataManager);
                isSynchronized = true;
            }
        }
    }
}