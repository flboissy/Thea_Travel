using System;
using System.Collections.Generic;
using Thea_Travel.Data.Interface;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    class FeuilleDeRoute : BindableObject, IFeuilleDeRoute
    {
        public DateTime Debut
        {
            get { return debut; }
            set { debut = value; }
        }
        private DateTime debut;

        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }
        private DateTime fin;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string id;
        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }
        private string titre;
        public List<IJournée> Journées => journées;
        private List<IJournée> journées = new List<IJournée>();

        public override string ToString()
        {
            return base.ToString();
        }
        public void ajouterJournée(IJournée j)
        {
            journées.Add(j);
        }

        public IVoyageur Voyageur
        {
            get { return voyageur; }
            set { voyageur = value; }
        }
        private IVoyageur voyageur;

        public ListeAdressesUtiles Adresses { get; }

        public void ajouterAdresse(IAdresseUtile addr)
        {
            Adresses.Add(addr);
        }

        public FeuilleDeRoute()
        {
            Adresses = new ListeAdressesUtiles();
        }
    }
}
