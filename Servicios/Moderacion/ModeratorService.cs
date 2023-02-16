using CommunityToolkit.Mvvm.ComponentModel;
using GestorRestReview.Servicios;
using Newtonsoft.Json;
using RestReviewV2.Servicios.Moderacion.clases;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion
{
    class ModeratorService : ObservableObject
    {
        private readonly string _baseUrl = "https://restmodreview.cognitiveservices.azure.com/contentmoderator/";
        private readonly string _subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";



        private AlertaServicio servicioAlerta;

        public ModeratorService()
        {
            servicioAlerta = new AlertaServicio();
        }

        public List<string> Moderate(string text)
        {
            var client = new RestClient(_baseUrl + "moderate/v1.0/ProcessText/Screen");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", text, ParameterType.RequestBody);

            var response = client.Execute(request);
            
            APIRootMod res = JsonConvert.DeserializeObject<APIRootMod>(response.Content);
            return res.Terms.Select(t => t.Term).ToList();
        }

        public List<string> Moderate(string text, string id)
        {
            return null;
        }


        // Gestion de listas

        public async Task<ObservableCollection<ListaModeracion>> GetAllLists()
        {
            ObservableCollection<ListaModeracion> lista = new ObservableCollection<ListaModeracion>();
            var client = new RestClient(_baseUrl + "lists/v1.0/termlists");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
            var response = client.Execute(request);

            List<APIRootListMod> listAPI = await LaunchAzureApi<List<APIRootListMod>>(client, request, "Error");
            lista = new ObservableCollection<ListaModeracion>(listAPI
                .Select(a => new ListaModeracion(null, a.Id.ToString()))
                .ToList());

            return lista;

        }

        public async Task<ObservableCollection<string>> GetTerms(string id)
        {
            
            var client = new RestClient(_baseUrl + $"lists/v1.0/termlists/{id}/terms");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
            request.AddParameter("language", "spa");

            APIRootList rootList = await LaunchAzureApi<APIRootList>(client, request, "Error").ConfigureAwait(true);

            List<string> list = new List<string>();

            if (list!=null)
            {
                rootList.Data.Terms.ForEach(t => list.Add(t.Term));
            }
            

            return new ObservableCollection<string>(list);
        }

        private async Task<T> LaunchAzureApi<T>(RestClient cli, RestRequest req, string exclude)
        {
            T res = default(T);
            int retries = 0;
            bool retry = true;

            while (retry)
            {
                retries++;
                try
                {
                    Debug.WriteLine(retries);
                    retry = false;
                    RestResponse response = (RestResponse)await cli.ExecuteAsync(req);
                    if (((int)response.StatusCode) == 429)
                    {
                        retry = true;
                        continue;
                    }
                    res = JsonConvert.DeserializeObject<T>(response.Content);
                    
                    retry = false;
                }
                catch (Exception)
                {

                }
            }

            return res;
        }



    }
}
