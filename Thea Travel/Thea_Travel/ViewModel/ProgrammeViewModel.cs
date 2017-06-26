using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thea_Travel.Data;

namespace Thea_Travel
{
    public class ProgrammeViewModel
    {
        public IProgramme Model { get; set; }
        public string ProgrammeType { get; set; }
        public ProgrammeViewModel(IProgramme p)
        {
            Model = p;
            ProgrammeType = p.GetType().Name;
            if(ProgrammeType.Equals("RendezVous"))
            {
                ProgrammeType = "Rendez-vous";
            }
        }
    }
}
