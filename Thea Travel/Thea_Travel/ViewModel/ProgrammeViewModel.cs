using MyMVVMToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thea_Travel.Data;
using Xamarin.Forms;

namespace Thea_Travel
{
    public class ProgrammeViewModel : BaseViewModel<IProgramme>
    {
        
        public string ProgrammeType {
            get
            {
                return Model.GetType().Name.Equals("RendezVous") ? "Rendez-Vous" : Model.GetType().Name;
            }
         }
        public ProgrammeViewModel(IProgramme p)
        {
            Model = p;
        }

     
    }
}
