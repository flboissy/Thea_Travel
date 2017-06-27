using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.Data
{
    public class AdresseUtile : IAdresseUtile
    {
        public string Nom { get; }

        public string Adresse { get; }

        public AdresseUtile(string n , string addr)
        {
            Nom = n;
            Adresse = addr;
        }
    }
}
