using System;
namespace Thea_Travel.Manager
{
    public partial class HttpHelper
    {
        public static readonly String domain = "transphyto";
        public static readonly String restBaseUrl = $"http://dev.laboratoires-thea.fr/déplacement/";
        public static readonly String lists = "_api/web/lists";
        public static readonly String listFDR = "_api/web/lists/GetByTitle('Feuille de route')/Items";
        public static readonly String itemByTitle = "/_api/web/lists/GetByTitle('Feuille de route')/Items?$filter=Title eq '{0}'";
        public static readonly String listItemsSelectProp = "/_api/web/lists/GetByTitle('Feuille de route')/Items?$select={0}";
    }
}