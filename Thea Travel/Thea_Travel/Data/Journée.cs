using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    public class Journée : IJournée
    {
        public DateTime DateDuJour
        {
            get { return dateDuJour; }
            set { dateDuJour = value; }
        }
        private DateTime dateDuJour;
        public IEnumerable<IProgramme> Programmes => programmes;
        private List<IProgramme> programmes = new List<IProgramme>();
        public void ajouterProgramme(IProgramme p)
        {
            programmes.Add(p);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}