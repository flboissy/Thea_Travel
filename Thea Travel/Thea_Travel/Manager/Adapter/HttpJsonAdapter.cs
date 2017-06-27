using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thea_Travel.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Thea_Travel.Fabrique;
using System.Globalization;
using System.Xml.Linq;
using System.Net;
using Thea_Travel.Ressources;
using Thea_Travel.Data.Interface;

namespace Thea_Travel.Manager
{
    class HttpJsonAdapter : IHttpResultAdapter
    {
        public HttpJsonAdapter()
        {
        }

        public async Task<IEnumerable<IFeuilleDeRoute>> resultToListFeuillesDeRoute(string httpResults)
        {
            JObject json = JObject.Parse(httpResults);
            JArray jarr = (JArray)json["d"]["results"];
            List<IFeuilleDeRoute> feuilles = new List<IFeuilleDeRoute>();

            foreach (JObject jobj in jarr)
            {
                feuilles.Add(resultToOneFeuilleDeRoute(jobj.ToString()));
            }
            return feuilles;
        }


        public IFeuilleDeRoute resultToOneFeuilleDeRoute(string httpResult)
        {
            IFeuilleDeRoute feuille = new FeuilleDeRoute();
            IEnumerable<IJournée> journees;
            IEnumerable<IAdresseUtile> adresses;
            JObject json = JObject.Parse(httpResult);

            feuille.Titre = (string)json[HttpHelper.CHAMP_TITRE];
            feuille.ID = (string)json[HttpHelper.CHAMP_ID];
            feuille.Debut = DateTime.ParseExact((((string)json[HttpHelper.CHAMP_DEBUT])).Remove(10), "MM/dd/yyyy", AppResources.Culture);
            feuille.Fin = DateTime.ParseExact(((string)json[HttpHelper.CHAMP_FIN]).Remove(10), "MM/dd/yyyy", AppResources.Culture);
            feuille.Voyageur = new Voyageur((string)json[HttpHelper.CHAMP_NOM_DE_COMPTE]);
            XDocument journeesXML = XDocument.Parse(WebUtility.HtmlDecode(json[HttpHelper.CHAMP_JOURNEES].ToString()));

            XDocument adressesXML = XDocument.Parse(WebUtility.HtmlDecode(json[HttpHelper.CHAMP_LISTE_ADRESSES].ToString()));
            journees = resultToJournees(journeesXML);
            adresses = resultToAdresses(adressesXML);
            foreach (IJournée j in journees)
            {
                feuille.ajouterJournée(j);
            }

            foreach (IAdresseUtile addr in adresses)
            {
                feuille.ajouterAdresse(addr);
            }

            return feuille;
        }

        private IEnumerable<IAdresseUtile> resultToAdresses(XDocument result)
        {
            return result.Descendants("Item").Select(elt => resultToOneAdresse(elt)).ToList();
        }

        private IAdresseUtile resultToOneAdresse(XElement result)
        {
            IAdresseUtile addr = new AdresseUtile(result.Element(HttpHelper.CHAMP_NOM_ADRESSE).Value, result.Element(HttpHelper.CHAMP_ADRESSE).Value);
            return addr;
        }

        public IEnumerable<IJournée> resultToJournees(XDocument result)
        {
            return result.Descendants("Item").Select(elt => resultToOneJournee(elt)).ToList();
        }

        public IJournée resultToOneJournee(XElement result)
        {
            IJournée journee = new Journée();
            IEnumerable<IProgramme> programmes;
            journee.DateDuJour = DateTime.ParseExact(result.Element(HttpHelper.CHAMP_DATE_DU_JOUR).Value.Remove(10), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            programmes = resultToProgrammes(XDocument.Parse(result.Element(HttpHelper.CHAMP_PROGRAMME).Value));

            foreach (IProgramme p in programmes)
            {
                journee.ajouterProgramme(p);
            }

            return journee;
        }

        public IEnumerable<IProgramme> resultToProgrammes(XDocument result)
        {
            return result.Descendants("Item").Select(elt => resultToOneProgramme(elt)).ToList();
        }

        public IProgramme resultToOneProgramme(XElement result)
        {
            string choixProg = WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_CHOIX_PROG).Value);
            string choixHeberge = WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_CHOIX_HEBERGEMENT).Value);
            string lookupAppartement = WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_LOOKUP_APPART).Value);
            string lookupHotel = WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_LOOKUP_HOTEL).Value);
            switch (choixProg)
            {
                case "Hébergement":
                    switch (choixHeberge)
                    {
                        case "Hôtel":
                            return resultToHotel(result, String.IsNullOrEmpty(lookupHotel));
                        case "Appartement":
                            return resultToAppartement(result, String.IsNullOrEmpty(lookupHotel));
                    }
                    return null;
                case "Rendez-vous":
                    return FabriqueRDV.CreerRDV(WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_PROGRAMME_INFO).Value));
                case "Autres informations":
                    return FabriqueAutre.CreerAutre(WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_PROGRAMME_INFO).Value));
                default:
                    return FabriqueTrajet.CreerTrajet(WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_PROGRAMME_INFO).Value));
            }
        }

        public IProgramme resultToHotel(XElement result, bool isLookup)
        {
            if (!isLookup)
            {
                return FabriqueHotel.creerHotel
                                   (
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.LOOKUP_PREFIX + HttpHelper.CHAMP_NOM_HOTEL).Value),
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.LOOKUP_PREFIX + HttpHelper.CHAMP_TEL_HOTEL).Value),
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.LOOKUP_PREFIX + HttpHelper.CHAMP_ADR_HOTEL).Value),
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_CHECK_IN).Value),
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_CHECK_OUT).Value)
                                   );
            }
            else
            {
                return FabriqueHotel.creerHotel
                                (
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.NO_LOOKUP_PREFIX + HttpHelper.CHAMP_NOM_HOTEL).Value),
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.NO_LOOKUP_PREFIX + HttpHelper.CHAMP_TEL_HOTEL).Value),
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.NO_LOOKUP_PREFIX + HttpHelper.CHAMP_ADR_HOTEL).Value),
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_CHECK_IN).Value),
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.CHAMP_CHECK_OUT).Value)
                                );
            }
        }

        public IProgramme resultToAppartement(XElement result, bool isLookup)
        {
            if (!isLookup)
            {
                return FabriqueAppartement.CreerAppartement
                                   (
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.LOOKUP_PREFIX + HttpHelper.CHAMP_NOM_APPARTEMENT).Value),
                                        WebUtility.HtmlDecode(result.Element(HttpHelper.LOOKUP_PREFIX + HttpHelper.CHAMP_ADR_APPARTEMENT).Value)
                                   );
            }
            else
            {
                return FabriqueAppartement.CreerAppartement
                                (
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.NO_LOOKUP_PREFIX + HttpHelper.CHAMP_NOM_APPARTEMENT).Value),
                                     WebUtility.HtmlDecode(result.Element(HttpHelper.NO_LOOKUP_PREFIX + HttpHelper.CHAMP_ADR_APPARTEMENT).Value)
                                );
            }
        }
    }
}
