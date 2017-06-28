using System.Collections.Generic;
using System.Threading.Tasks;
using Thea_Travel.Manager.DataManager;

namespace Thea_Travel.Data
{
    public class ListeFeuillesDeRoute
    {
        public IEnumerable<IFeuilleDeRoute> Feuilles => feuilles;
        private List<IFeuilleDeRoute> feuilles;

        async public Task initFeuillesDeRoute(IDataManager manager)
        {
            feuilles = new List<IFeuilleDeRoute>(await manager.ChargerFeuilleDeRoute());
        }
    }
}
