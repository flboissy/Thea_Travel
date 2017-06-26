

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Thea_Travel.Data
{
    public interface IJournée
    {
        DateTime DateDuJour { get; set; }
        IEnumerable<IProgramme> Programmes { get; }

        void ajouterProgramme(IProgramme p);
    }
}