using GestorRestReview.Servicios;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion
{
    class ModeratorService
    {
        private readonly string _baseUrl = "https://restmodreview.cognitiveservices.azure.com/";
        private readonly string _subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";
        private readonly string terms = "contentmoderator/moderate/v1.0/ProcessText/Screen";

        public ModeratorService()
        {
        }

        public async Task<CustomListResponse> AddCustomListTerm()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(terms, Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("listId", );
            request.AddParameter("text/plain", "texto");

            var response = await client.ExecuteAsync<CustomListResponse>(request);
            return response.Data;
        }
    }
}
