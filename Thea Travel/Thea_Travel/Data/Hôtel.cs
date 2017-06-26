using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    class Hôtel : Hebergement
    {
       
        public string Tel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Hôtel(string nom, string tel, string adresse, DateTime checkIn, DateTime checkOut)
        {
            Nom = nom;
            Tel = tel;
            Adresse = adresse;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
