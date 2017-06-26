using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;

namespace Thea_Travel.Fabrique
{
    public static class FabriqueAppartement
    {
        public static IProgramme CreerAppartement(string nom, string adresse)
        {
            return new Appartement(nom, adresse);
        }
    }
}
