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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion
{
    /// <summary>
    /// Servicio que interactúa con la API de Content Moderator de Azure.
    /// </summary>
    class ModeratorService : ObservableObject
    {
        private readonly string _baseUrl = "https://restmodreview.cognitiveservices.azure.com/contentmoderator/";
        private readonly string _subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";

        private AlertaServicio servicioAlerta;

        /// <summary>
        /// Constructor que inicializa la instancia del servicio de alertas.
        /// </summary>
        public ModeratorService()
        {
            servicioAlerta = new AlertaServicio();
        }

        /// <summary>
        /// Método que realiza la moderación de un texto.
        /// </summary>
        /// <param name="text">Texto a moderar.</param>
        /// <returns>Lista de términos moderados.</returns>
        public async Task<List<string>> Moderate(string text)
        {
            var client = new RestClient(_baseUrl + "moderate/v1.0/ProcessText/Screen");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", text, ParameterType.RequestBody);

            APIRootMod res = await LaunchAzureApi<APIRootMod>(client, request);
            return res.Terms.Select(t => t.Term).ToList();
        }

        /// <summary>
        /// Método que realiza la moderación de un texto.
        /// </summary>
        /// <param name="text">Texto a moderar.</param>
        /// <param name="id">Identificador del texto.</param>
        /// <returns>Lista de términos moderados.</returns>
        public List<string> Moderate(string text, string id)
        {
            return null;
        }

        /// <summary>
        /// Método que obtiene todas las listas de moderación disponibles.
        /// </summary>
        /// <returns>Colección observable de listas de moderación.</returns>
        public async Task<ObservableCollection<ListaModeracion>> GetAllLists()
        {
            ObservableCollection<ListaModeracion> lista = new ObservableCollection<ListaModeracion>();
            var client = new RestClient(_baseUrl + "lists/v1.0/termlists");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);

            List<APIRootListMod> listAPI = await LaunchAzureApi<List<APIRootListMod>>(client, request);
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

            APIRootList rootList = await LaunchAzureApi<APIRootList>(client, request).ConfigureAwait(true);

            List<string> list = new List<string>();
             if (rootList.Data.Terms.Count > 0)
            {
                rootList.Data.Terms.ForEach(t => list.Add(t.Term));
            }

            return new ObservableCollection<string>(list);
        }


        public async Task<bool> AddTerm(string id, string term)
        {
            var client = new RestClient(_baseUrl + $"lists/v1.0/termlists/{id}/terms/{term}?language=spa");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);

            RestResponse response = (RestResponse)client.Execute(request);
            Debug.WriteLine(response.Content);
            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> DeleteTerm(string id, string term)
        {
            var client = new RestClient(_baseUrl + $"lists/v1.0/termlists/{id}/terms/{term}?language=spa");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);

            RestResponse response = (RestResponse)client.Execute(request);
            return (int)response.StatusCode == 200;
        }

        /// <summary>
        /// Método que obtiene los términos de una lista de moderación.
        /// </summary>
        /// <param name="id">Identificador de la lista.</param>
        /// <returns>Colección observable de términos de la lista.</returns>
        private async Task<T> LaunchAzureApi<T>(RestClient cli, RestRequest req)
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
                        ForceWait(600);
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

        public void ForceWait(Double ms)
        {
            DateTime wait = DateTime.Now.AddMilliseconds(ms);
            while (DateTime.Now < wait) { }
            return;
            
        }
        



    }
}
