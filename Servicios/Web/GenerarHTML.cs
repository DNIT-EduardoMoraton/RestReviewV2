using GestorRestReview.BD;
using GestorRestReview.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Web
{
    class GenerarHTML
    {
        private SeccionService seccion = new SeccionService();


        public GenerarHTML()
        {

        }

        public string GenerateHTML()
        {
            string html;
            int contador;
            html = "<html><body><h1>Revista</h1>";
            contador = 0;

            foreach (Seccion data in seccion.GetAll())
            {
                html += "<h2>Seccion " +
                        + contador + " </h2>" +
                        "<p>Nombre: " + data.Nombre + "</p>" +
                        "<p>Descripcion: " + data.Descripcion + "</p>";
                contador++;
            }

            html += "</body></html>";


            return html;
            
        }

        public void saveTo(string path) 
        {
            File.WriteAllText(path, GenerateHTML()); // Controlar errores
        }

        public string getPreview()
        {
            saveTo("./Assets/web/webplantilla.html"); // G
            return "./Assets/web/webplantilla.html";
        }




    }
}
