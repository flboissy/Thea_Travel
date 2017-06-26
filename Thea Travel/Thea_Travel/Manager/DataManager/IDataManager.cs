using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;

namespace Thea_Travel.Manager.DataManager
{
    public interface IDataManager
    {
        Task<IEnumerable<IFeuilleDeRoute>> ChargerFeuilleDeRoute();
    }
}
