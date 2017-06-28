using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVMToolkit;
using Thea_Travel.Data;

namespace Thea_Travel.ViewModel
{
    public class VoyageurViewModel : BaseViewModel<IVoyageur>
    {
        public VoyageurViewModel(IVoyageur v)
        {
            Model = v;
        }

        public string NomDeCompte
        {
            get { return Model.NomDeCompte; }
            set { SetProperty(Model.NomDeCompte, value, () => Model.NomDeCompte = value); }
        }
    }
}
