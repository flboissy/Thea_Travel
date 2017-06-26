using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Manager
{
    public static partial class HttpHelper
    {
        public static readonly string LOOKUP_PREFIX = "lookup";
        public static readonly string NO_LOOKUP_PREFIX = "textBox";
        public static readonly string CHAMP_CHOIX_PROG = "choixProgramme";
        public static readonly string CHAMP_CHOIX_HEBERGEMENT = "ChoixHeberge";
        public static readonly string CHAMP_LOOKUP_APPART = LOOKUP_PREFIX + "Appartement";
        public static readonly string CHAMP_LOOKUP_HOTEL = LOOKUP_PREFIX + "Hotel";
        public static readonly string CHAMP_NOM_APPARTEMENT = "NomA";
        public static readonly string CHAMP_NOM_HOTEL = "NomH";
        public static readonly string CHAMP_TEL_HOTEL = "TelH";
        public static readonly string CHAMP_ADR_HOTEL = "AdrH";
        public static readonly string CHAMP_ADR_APPARTEMENT = "AdrA";
        public static readonly string CHAMP_CHECK_IN = "DateCheckIn";
        public static readonly string CHAMP_CHECK_OUT= "DateCheckOut";
        public static readonly string CHAMP_PROGRAMME_INFO = "Multilineprogramme";
    }
}