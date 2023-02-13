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

namespace RestReviewV2.Servicios.PDF
{
    class PDFService
    {

        BlobService azureService;
        private Articulo articulo;
        private Autor autor;

        public PDFService(){}

        public void Generate(Articulo articulo)
        {
            azureService = new BlobService();
            this.articulo = articulo;
            autor = articulo.Autor;

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

                        string articuloImagen = azureService.download(articulo.Imagen);
                        
                        column.Item()
                        .AspectRatio(16 / 9f)
                        .Image(articuloImagen);

                        ///////////////////////////////////

                        string redSocial = "";

                        switch (autor.Redsocial)
                        {
                            case "Twitter":
                                redSocial = "Assets/imgs/twitter-icono.jpg";
                                break;
                            case "Instagram":
                                redSocial = "Assets/imgs/twitter.png";
                                break;
                            case "Facebook":
                                redSocial = "Assets/imgs/twitter-icono.jpg";
                                break;
                            default:
                                break;
                        }

                        ///////////////////////////////////


                        //column.Item().AspectRatio(16 / 9f).Image(redSocial);
                        column.Item()
                        .AlignCenter()
                        .Padding(15)
                        .DefaultTextStyle(x => x.FontSize(16))
                        .Row(row =>
                        {
                            row.AutoItem().Width(2, Unit.Centimetre).Image(redSocial);
                            row.AutoItem().PaddingHorizontal(10).LineVertical(1).LineColor(Colors.Grey.Medium);
                            row.AutoItem().Text(autor.NickName);
                            row.AutoItem().PaddingHorizontal(10).LineVertical(1).LineColor(Colors.Grey.Medium);
                            String autorImagen = azureService.download(autor.Imagen);
                            row.AutoItem().Width(2,Unit.Centimetre).Image(autorImagen);

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
            }).GeneratePdf("pdfarticulos/" + "Articulo_" + articulo.Id +".pdf");
        }
    }
}


