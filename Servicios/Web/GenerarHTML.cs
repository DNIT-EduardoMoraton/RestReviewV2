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

        public void GenerateHTML()
        {
            // Iniciar la cadena HTML
            string html = "<html><body><h1>Revista</h1>";


            foreach (Seccion data in seccion.GetAll())
            {
                html += "<h2>Seccion</h2>" +
                        "<p>Nombre: " + data.Nombre + "</p>" +
                        "<p>Descripcion: " + data.Descripcion + "</p>";
            }

            html += "</body></html>";

            
            // Escribir el HTML en un archivo
            File.WriteAllText("data.html", html);
        }
    }
}
