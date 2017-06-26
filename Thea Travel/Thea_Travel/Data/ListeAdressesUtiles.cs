using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.Data
{
    class ListeAdressesUtiles
    {
        public IEnumerable<IAdresseUtile> Adresses => adresses;
        private List<IAdresseUtile> adresses;

        async public Task initAdressesUtiles()
        {

        }
    }
}
