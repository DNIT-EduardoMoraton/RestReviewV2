using GestorRestReview.BD;
using GestorRestReview.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        string imagen, titulo, texto, htmlHeader, htmlArticulo, htmlContenido = "";
        int contador = 0;
        ObservableCollection<Articulo> articuloscargados;

        public GenerarHTML()
        {
            
        }

        public string GenerateHTML()
        {
            articuloscargados = articulos.getAll();

            htmlContenido =
                "<!DOCTYPE html>\n" +
                "<html>\n" +
                "<head>\n" +
                "<title> W3.CSS Template </title>\n" +
                "<meta charset = 'UTF-8'>\n" +
                "<meta name = 'viewport' content = 'width=device-width, initial-scale=1'>\n" +
                "<link rel = 'stylesheet' href = 'w3.css'>\n" +
                "<link rel = 'stylesheet' href = 'fontface.css'>\n" +
                "<style>\n" +
                "body,h1,h2,h3,h4,h5,h6 {font - family: 'Raleway', sans - serif}\n" +
                "</style>\n" +
                "</head>\n" +
                "<body class='w3-light-grey w3-content'>\n" +
                "<div class='w3-main'>\n" +
                "<header id = 'portfolio'>\n" +
                "<div class='w3-container'>\n" +
                "<h1><b>Gusto Guru</b></h1>\n" +
                "<div class='w3-section w3-bottombar w3-padding-16'>\n" +
                "<span class='w3-margin-right'>Filter:</span>\n" +
                "<button class='w3-button w3-black'>ALL</button>\n" +
                "<button class='w3-button w3-white'>Design</button>\n" +
                "<button class='w3-button w3-white w3-hide-small'>Photos</button>\n" +
                "<button class='w3-button w3-white w3-hide-small'>Art</button>\n" +
                "</div>\n" +
                "</div>\n" +
                "</header>\n" +
                "<body class='w3-light-grey w3-content'>\n" +
                "<div class='w3-main'>\n" +
                "<div class='w3-row-padding'>\n";


            foreach(Articulo a in articuloscargados)
            {
                imagen = a.Imagen;
                titulo = a.Titulo;
                texto = a.Texto.Substring(0, 1) + "...";
                htmlArticulo =
                    "<div class='w3-row-padding'>\n" +
                    "<div class='w3-third w3-container w3-margin-bottom'>\n" +
                    "<img src = '" + imagen + "' alt='Image' style='width:100%' class='w3-hover-opacity'>\n" +
                    "<div class='w3-container w3-white'>\n" +
                    "<p><b>" + titulo + "</b></p>\n" +
                    "<p>" + texto + "</p>\n</div>\n</div>\n";

                htmlContenido += htmlArticulo;
                contador++;

                if (contador % 3 == 0)
                {
                    htmlContenido = htmlContenido + "/div\n" + "<div class='w3-row-padding'>\n";
                }
            }
            htmlContenido += "/div\n";
                

            return htmlHeader + htmlContenido + "</body>\n" + "</html> ";
        }

        public void SaveTo(string path)
        {
            if (path==null)
                return;
            File.WriteAllText(path, GenerateHTML()); // Controlar errores
        }

        public string getPreview()
        {
            SaveTo("./Assets/web/plantilla.html"); // G
            return "./Assets/web/plantilla.html";
        }




    }
}
