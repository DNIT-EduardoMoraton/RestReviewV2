using GestorRestReview.Servicios;
using Newtonsoft.Json;
using RestReviewV2.Servicios.Moderacion.clases;
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
        private readonly string _baseUrl = "https://restmodreview.cognitiveservices.azure.com/contentmoderator/";
        private readonly string _subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";
        AlertaServicio servicioAlerta;

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
            servicioAlerta.MessageBoxError(response.StatusCode.ToString());
            APIRootMod res = JsonConvert.DeserializeObject<APIRootMod>(response.Content);
            return res.Terms.Select(t => t.Term).ToList();
        }

        public 


    }
}
