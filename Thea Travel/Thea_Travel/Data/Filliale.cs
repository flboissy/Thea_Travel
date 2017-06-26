using System;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.Data
{
    class Filliale : IAdresseUtile
    {
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public Filliale(String nom, String adresse, String telephone)
        {
            Nom = nom;
            Adresse = adresse;
            Telephone = telephone;
        }
    }
}
