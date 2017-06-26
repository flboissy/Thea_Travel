using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    class Autre : IProgramme
    {


        public string Information { get; set; }
      

        public Autre(string information)
        {
            Information = information;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
