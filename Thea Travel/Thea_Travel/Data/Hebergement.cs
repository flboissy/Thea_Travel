using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    abstract class Hebergement : BindableObject, IProgramme
    {
        public string Nom { get; set; }


        public string Adresse { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public abstract Task ActionSheet();
    }
}
