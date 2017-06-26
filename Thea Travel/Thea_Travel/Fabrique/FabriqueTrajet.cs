using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;

namespace Thea_Travel.Fabrique
{
    public static class FabriqueTrajet
    {
        public static IProgramme CreerTrajet(string information)
        {
            return new Trajet(information);
        }
    }
}
