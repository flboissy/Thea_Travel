using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Data
{
    class Voyageur : IVoyageur
    {
        
        public string NomDeCompte { get; set; }
       
        public Voyageur(string ndc)
        {
            NomDeCompte = ndc;
        }
    }
}
