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
        private SeccionService secciones = new SeccionService();
        private ArticuloService articulos = new ArticuloService();
        string imagen, titulo, texto, seccion, htmlHeader, htmlArticulo, htmlContenido = "";
        int contador = 0;
        ObservableCollection<Seccion> seccionescargadas;
        ObservableCollection<Articulo> articuloscargados;
        public GenerarHTML()
        {
            
        }

        public string GenerateHTML()
        {
            seccionescargadas = secciones.GetAll();
            articuloscargados = articulos.GetAll();

            htmlContenido =
                "<!DOCTYPE html>\n" +
                "<html>\n" +
                "<head>\n" +
                    "<title>GustoGuru</title>\n" +
                    "<meta charset = 'UTF-8'>\n" +
                    "<meta name = 'viewport' content = 'width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0'>\n" +
                    "<link rel = 'stylesheet' href = 'estilos.css'>\n" +
                    "<link rel = 'stylesheet' href = 'https://fonts.googleapis.com/css?family=Open+Sans:400,600,700'>\n" +
                    "<script src=0+'js / jquery - 3.2.1.js'></script>\n" +
                    "<script src='js / script.js'></script>\n" +
                "</head>\n" +
                "<body>\n" +

                    "<div class='wrap'>\n" +
                        "<h1>Nombre</h1>\n" +
                        "<div class='store-wrapper>\n" +
                             "<div class='category_list'>\n" +
                                "< a href = '#' class='category_item' category='all'>Todo</a>\n";

            foreach (Articulo a in articuloscargados)
            {
                seccion = a.Seccion.Nombre;
                htmlContenido += "< a href = '#' class='category_item' category='" + seccion + "'>Todo</a>\n";
            }

            htmlContenido +=
                "</div>\n" +
                "<section class='products - list'>\n";

            foreach(Articulo a in articuloscargados)
            {
                imagen = a.Imagen;
                titulo = a.Titulo;
                seccion = a.Seccion.Nombre;
                texto = a.Texto.Substring(0, 10) + "...";
                htmlArticulo = "<div class='product - item' category='laptops'>\n" +
                    "<img src='images / laptop_hp.jpg' alt='' >\n" +
                    "<a href='#'>Laptop Hp</a>\n" +
                    "</div>\n";

                htmlContenido += htmlArticulo;
               
            }
            htmlContenido += "</section>\n" +
                "</div>\n" +
                "</div>\n" +
                "</body>\n" +
                "</html>\n";
                

            return htmlContenido;
        }

        public void SaveTo(string path)
        {
            if (path==null)
                return;
            File.WriteAllText(path, GenerateHTML()); // Controlar errores
        }

        public string GetPreview()
        {
            SaveTo("./Assets/web/webplantilla.html"); // G
            return "./Assets/web/webplantilla.html";
        }

    }
}
