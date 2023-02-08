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
        private readonly string _baseUrl = "https://southafricanorth.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0/ProcessText/Screen?";
        private readonly string _subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";

        public ModeratorService()
        {
        }

        public async Task<CustomListResponse> AddCustomListTerm(CustomListTerm term)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("terms", Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(term);

            var response = await client.ExecuteAsync<CustomListResponse>(request);
            return response.Data;
        }
    }
}
