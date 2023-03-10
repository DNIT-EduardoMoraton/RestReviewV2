using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer; 
using QuestPDF.Infrastructure;
using GestorRestReview.Modelo;
using GestorRestReview.BD;
using RestReviewV2.Servicios.BD;
using System.IO;

namespace RestReviewV2.Servicios.PDF
{

    /// <summary>
    /// Servicio encargado de generar un archivo PDF con los datos del artículo y autor proporcionados.
    /// </summary>
    class PDFService
    {

        BlobService azureService;
        private Articulo articulo;
        private Autor autor;
        private string rutapdf;


        /// <summary>
        /// Constructor de la clase PDFService.
        /// </summary>
        public PDFService(){}


        /// <summary>
        /// Genera un archivo PDF a partir de los datos de un artículo.
        /// </summary>
        /// <param name="articulo">Artículo a partir del cual se va a generar el PDF.</param>
        /// <returns>Ruta donde se encuentra el archivo PDF generado.</returns>
        public string Generate(Articulo articulo)
        {
            azureService = new BlobService();
            this.articulo = articulo;
            autor = articulo.Autor;
            Directory.CreateDirectory("pdfarticulos/");
            rutapdf = "pdfarticulos/" + "Articulo_" + articulo.Id + ".pdf";
            FileStream articuloImagenFs;
            FileStream fotoAutorFs;
            FileStream fotoRedSocial;
            //Descarga Imagenes de Azure
            string autorImagen = azureService.download(autor.Imagen);
            string articuloImagen = azureService.download(articulo.Imagen);
            string redSocialImagen = "";
            switch (autor.Redsocial)
            {
                case "Twitter":
                    redSocialImagen = "Assets/imgs/twitter.png";
                    break;
                case "Instagram":
                    redSocialImagen = "Assets/imgs/instagram.png";
                    break;
                case "Facebook":
                    redSocialImagen = "Assets/imgs/facebook.png";
                    break;
                default:
                    break;
            }
            //Abre el stream de cada una
            fotoAutorFs = new FileStream(autorImagen, FileMode.Open);
            articuloImagenFs = new FileStream(articuloImagen, FileMode.Open);
            fotoRedSocial = new FileStream(redSocialImagen, FileMode.Open);



            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(1, Unit.Inch);
                    page.Header()
                    .Text(articulo.Titulo)
                    .FontSize(48)
                    .FontColor(Colors.Blue.Darken2)
                    .SemiBold();
                    page.Content()
                    .Column(column =>
                    {
                        column.Spacing(0.5f, Unit.Inch);

                        column.Item()
                        .Text(articulo.Texto)
                        .FontSize(18);

                        column.Item()
                        .AspectRatio(16 / 9f)
                        .Image(articuloImagenFs);

                        ///////////////////////////////////


                        column.Item()
                        .AlignCenter()
                        .Padding(15)
                        .DefaultTextStyle(x => x.FontSize(16))
                        .Row(row =>
                        {
                            row.AutoItem().Width(2, Unit.Centimetre).Image(redSocialImagen);
                            row.AutoItem().PaddingHorizontal(10).LineVertical(1).LineColor(Colors.Grey.Medium);
                            row.AutoItem().Text(autor.NickName);
                            row.AutoItem().PaddingHorizontal(10).LineVertical(1).LineColor(Colors.Grey.Medium);
                            row.AutoItem().Width(2,Unit.Centimetre).Image(fotoAutorFs);

                            

                        });
                        
                    });

                    page.Footer()
                    .AlignCenter()
                    .Text(text =>
                    {
                        
                        text.DefaultTextStyle(x => x.FontSize(18));
                        text.CurrentPageNumber();
                        text.Span("/");
                        text.TotalPages();
                    });
                });
                
            }).GeneratePdf(rutapdf);

            //Close
            articuloImagenFs.Close();
            fotoAutorFs.Close();
            fotoRedSocial.Close();
            //Delete
            File.Delete(autorImagen);
            File.Delete(articuloImagen);

            return rutapdf;
        }
    }
}


