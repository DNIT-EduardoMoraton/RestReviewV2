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

    /// <summary>
    /// Clase que genera un archivo HTML con contenido dinámico basado en datos de secciones y artículos.
    /// </summary>
    class GenerarHTML
    {
        private SeccionService secciones = new SeccionService();
        private ArticuloService articulos = new ArticuloService();
        DateTime fecha;
        string imagen, titulo, seccion, texto, htmlArticulo, htmlContenido = "";
        ObservableCollection<Seccion> seccionescargadas;
        ObservableCollection<Articulo> articuloscargados;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public GenerarHTML()
        {
            
        }

        /// <summary>
        /// Genera un archivo HTML con contenido dinámico basado en datos de secciones y artículos.
        /// </summary>
        /// <returns>El contenido del archivo HTML generado.</returns>
        public string GenerateHTML()
        {
            seccionescargadas = secciones.GetAll();
            articuloscargados = articulos.GetAllPublicados();

            htmlContenido =
                "<!DOCTYPE html>\n" +
                "<html>\n" +
                    "<head>\n" +
                        "<meta charset='utf-8'>\n" +
                        "<meta http-equiv='X-UA-Compatible' content='IE=edge'>\n" +
                        "<title>Tu Restaurante</title>\n" +
                        "<meta name='viewport' content='width=device-width, initial-scale=1'>\n" +
                        "<link rel='stylesheet' href='main.css'>\n" +
                        "<script src='https://kit.fontawesome.com/dbed6b6114.js' crossorigin='anonymous'></script>\n" +
                    "</head>\n" +
                    "<body>\n" +
                        "<div class='main-container'>\n" +
                            "<h1>Restaurant Review</h1>\n" +
                            "<p>Reseña de tu restaurante favorito</p>\n" +
                            "<div class = 'filter-container'>\n" +
                                 "<div class='category-head'>\n" +
                                 "<ul>\n" +
                                 "<div class = 'category-title active' id = 'all'>\n" +
                                 "<li>Todo</li>\n" +
                                    "<span><i class = 'fas fa-border-all'></i></span>\n" +
                                    "</div>\n";

            foreach (Seccion s in seccionescargadas)
            {
                seccion = s.Nombre;
                htmlContenido += "<div class = 'category-title' id = '" + seccion.ToLower() + "'>\n" +
                                    "<li>" + seccion + "</li>\n" +
                                    "<span><i class = 'fas fa-hamburger'></i></span>\n" +
                                "</div>\n";
            }

            htmlContenido += "</ul>\n" +
                "</div>\n" +
                "<div class = 'posts-collect'>\n" +
                "<div class = 'posts-main-container'>\n";

            foreach(Articulo a in articuloscargados)
            {
                fecha = a.FechaPublicacionDate;
                imagen = a.Imagen;
                titulo = a.Titulo;
                seccion = a.Seccion.Nombre;
                texto = a.Texto;
                htmlArticulo = "<div class = 'all " + seccion.ToLower() + "'>\n" +
                                    "<div class = 'post-img'>\n" +
                                        "<img src = '" + imagen + "' alt = 'post'>\n" +
                                        "<span class = 'category-name'>" + seccion.ToLower() +"</span>\n" +
                                    "</div>\n" +
                                    "<div class = 'post-content'>\n" +
                                        "<div class = 'post-content-top'>\n" +
                                            "<span><i class = 'fas fa-calendar'></i>" + fecha + "</span>\n" +
                                        "</div>\n" +
                                        "<h2>" + titulo + "</h2>\n" +
                                        "<p class='cutoff-text'>" + texto + "</p>\n" +
                                    "</div>\n" +
                                "</div>\n";

                htmlContenido += htmlArticulo;
            }
            htmlContenido += "</div>\n" +
                        "</div>\n" +
                    "</div>\n" +
                "</div>\n" +
                "<script src = 'script.js'></script>\n" +
            "</body>\n" +
        "</html>\n";
                

            return htmlContenido;
        }

        /// <summary>
        /// Guarda el contenido generado en un archivo HTML en la ruta especificada.
        /// </summary>
        /// <param name="path">La ruta donde se guardará el archivo HTML.</param>
        public void SaveTo(string path)
        {
            if (path==null)
                return;
            File.WriteAllText(path, GenerateHTML()); // Controlar errores
        }


        /// <summary>
        /// Genera el archivo HTML y lo guarda en la ruta "./Assets/web/webplantilla.html".
        /// </summary>
        /// <returns>La ruta donde se guardó el archivo HTML.</returns>
        public string GetPreview()
        {
            SaveTo("./Assets/web/webplantilla.html"); // G
            return "./Assets/web/webplantilla.html";
        }

    }
}
