using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Thea_Travel.Data;
using System.Xml.Linq;
using System.Linq;
using Xamarin.Forms;
using Thea_Travel.Services;
using Thea_Travel.Manager.DataManager;

namespace Thea_Travel.Manager
{
    class HttpDataManager : IDataManager
    {
        private HttpClientHandler handler;
        private HttpClient client;
        private IHttpResultAdapter adapter;
        private Authenticator auth;

        public HttpDataManager()
        {
            auth = Authenticator.getAuthenticator();
            adapter = new HttpJsonAdapter();
        }
        
        
        public async Task<IEnumerable<IFeuilleDeRoute>> ChargerFeuilleDeRoute()
        {
            handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(auth.Username, auth.Password, HttpHelper.domain);
            client = new HttpClient(handler);
            client.BaseAddress = new Uri($"http://dev.laboratoires-thea.fr/déplacement/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
            var response = await client.GetAsync("_api/web/lists/GetByTitle('Feuille de route')/Items");
            string result = await response.Content.ReadAsStringAsync();
            SauvegarderFeuilleFromHttpResult(result);
            return  await adapter.resultToListFeuillesDeRoute(result);
        }

        public void SauvegarderFeuilleFromHttpResult(string result)
        {
            DependencyService.Get<ISaveAndLoad>().SaveText("feuilles.json", result);
        }
    }
}
