using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Data
{
    class Appartement : Hebergement
    {
        public Appartement(string nom, string adresse)
        {
            Nom = nom;
            Adresse = adresse;
        }
    }
}
