using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.Data
{
    public class ListeAdressesUtiles
    {
        public ListeAdressesUtiles()
        {
            adresses = new List<IAdresseUtile>();
        }

        public IEnumerable<IAdresseUtile> Adresses => adresses;
        private List<IAdresseUtile> adresses;

        public void Add(IAdresseUtile addr)
        {
            adresses.Add(addr);
        }
    }
}
