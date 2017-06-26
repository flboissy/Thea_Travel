using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    public class Journée : BindableObject, IJournée
    {
        public static readonly BindableProperty DateDuJourProperty =
        BindableProperty.Create("DateDuJour", typeof(DateTime), typeof(Journée), DateTime.Today); 
        public DateTime DateDuJour
        {
            get { return (DateTime)GetValue(DateDuJourProperty); }
            set { SetValue(DateDuJourProperty, value); }
        }
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