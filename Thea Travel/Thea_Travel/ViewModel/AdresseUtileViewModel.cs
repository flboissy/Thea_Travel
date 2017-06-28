
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVMToolkit;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.ViewModel
{
    public class AdresseUtileViewModel : BaseViewModel<IAdresseUtile>
    {
        public string Nom
        {
            get { return Model.Nom; }
        }

        public string Adresse
        {
            get { return Model.Adresse; }
        }

        public AdresseUtileViewModel(IAdresseUtile addr)
        {
            Model = addr;
        }
    }
}
