using GestorRestReview.Servicios;
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
        public ModeratorService()
        {
        }

        public string ModerarTexto(String texto)
        {
            var client = new HttpClient();
            AlertaServicio alerta = new AlertaServicio();
            var subscriptionKey = "e2ea035cffd64e74bf391609868d1faf";
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = "https://southafricanorth.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0/ProcessText/Screen?";
            var content = new StringContent(texto, Encoding.UTF8, "text/plain");

            var response = client.PostAsync(uri, content).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
