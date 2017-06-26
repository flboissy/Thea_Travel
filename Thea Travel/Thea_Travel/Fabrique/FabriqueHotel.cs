using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;

namespace Thea_Travel.Fabrique
{
    public static class FabriqueHotel
    {
        public static IProgramme creerHotel(string nom, string tel, string adresse, string chin, string chout)
        {
            DateTime checkIn = DateTime.ParseExact(chin.Remove(10), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime checkOut = DateTime.ParseExact(chout.Remove(10), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            return new Hôtel(nom, tel, adresse, checkIn, checkOut);
        }
    }
}
