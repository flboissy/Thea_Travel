using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    class FeuilleDeRoute : BindableObject, IFeuilleDeRoute
    {
        public static readonly BindableProperty DebutProperty =
        BindableProperty.Create("Debut", typeof(DateTime), typeof(FeuilleDeRoute), DateTime.Today);
        public DateTime Debut
        {
            get { return (DateTime)GetValue(DebutProperty); }
            set { SetValue(DebutProperty, value); }
        }
        public static readonly BindableProperty FinProperty =
        BindableProperty.Create("Fin", typeof(DateTime), typeof(FeuilleDeRoute), DateTime.Today);
        public DateTime Fin
        {
            get { return (DateTime)GetValue(FinProperty); }
            set { SetValue(FinProperty, value); }
        }
        public static readonly BindableProperty IDProperty =
        BindableProperty.Create("ID", typeof(string), typeof(FeuilleDeRoute), "ID");
        public string ID
        {
            get { return (string)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }
        public static readonly BindableProperty TitreProperty =
        BindableProperty.Create("Titre", typeof(string), typeof(FeuilleDeRoute), "Feuille de route");
        public string Titre
        {
            get { return (string)GetValue(TitreProperty); }
            set { SetValue(TitreProperty, value); }
        }
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
        public IVoyageur Voyageur { get; set; }

        public IEnumerable<string> Adresses
        {
            get { return adresses; }
        }
        private List<string> adresses = new List<string>();

        public void ajouterAdresse(string addr)
        {
            adresses.Add(addr);
        }

        public FeuilleDeRoute() { }
    }
}
