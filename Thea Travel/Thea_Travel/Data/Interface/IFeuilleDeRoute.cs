using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.Data
{
    public interface IFeuilleDeRoute
    {
        DateTime Debut { get; set; }
        DateTime Fin { get; set; }
        string Titre { get; set; }
        string ID { get; set; }
        IVoyageur Voyageur { get; set; }
        List<IJournée> Journées { get; }
        ListeAdressesUtiles Adresses { get; }
        void ajouterJournée(IJournée j);
        void ajouterAdresse(IAdresseUtile addr);
    }
}
