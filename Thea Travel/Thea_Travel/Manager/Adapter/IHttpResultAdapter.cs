using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thea_Travel.Data;

namespace Thea_Travel.Manager
{
    interface IHttpResultAdapter
    {
        Task<IEnumerable<IFeuilleDeRoute>> resultToListFeuillesDeRoute(string httpResults);
        IFeuilleDeRoute resultToOneFeuilleDeRoute(string httpResult);

        IEnumerable<IJournée> resultToJournees(XDocument result);

        IJournée resultToOneJournee(XElement result);

        IEnumerable<IProgramme> resultToProgrammes(XDocument result);

        IProgramme resultToOneProgramme(XElement result);
    }
}
