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
    class ContentModeratorClient
    {
        private readonly string _baseUrl = "https://southafricanorth.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0/ProcessText/Screen?";
        private readonly string _subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";

        public ContentModeratorClient(string subscriptionKey)
        {
            _subscriptionKey = subscriptionKey;
        }

        public T Get<T>(string endpoint)
        {
            var client = new RestClient(_baseUrl + endpoint);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
