using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;
using Thea_Travel.Manager.DataManager;
using Thea_Travel.Services;
using Xamarin.Forms;

namespace Thea_Travel.Manager
{
    public class OfflineDataManager : IDataManager
    {
        IHttpResultAdapter adapter;
        public OfflineDataManager()
        {
            adapter = new HttpJsonAdapter();
        }

        public async Task<IEnumerable<IFeuilleDeRoute>> ChargerFeuilleDeRoute()
        {
            string result = DependencyService.Get<ISaveAndLoad>().LoadText("feuilles.json");
            return (await adapter.resultToListFeuillesDeRoute(result));
        }

  
    }
}
