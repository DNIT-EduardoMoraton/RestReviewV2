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
        private SeccionService seccions = new SeccionService();
        private ArticuloService articulos = new ArticuloService();
        private SeccionService secciones = new SeccionService();

        public GenerarHTML()
        {

        }

        public string GenerateHTML()
        {
            string html = "";
                

            return html;
            
        }

        public void saveTo(string path) 
        {
            if (path==null)
                return;
            File.WriteAllText(path, GenerateHTML()); // Controlar errores
        }

        public string getPreview()
        {
            saveTo("./Assets/web/webplantilla.html"); // G
            return "./Assets/web/webplantilla.html";
        }




    }
}
