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
    class PDFGenerator
    {

        BlobService azureService;
        private Articulo articulo;
        private Autor autor;

        public PDFGenerator(Articulo articulo,Autor autor)
        {
            azureService = new BlobService();
            this.articulo = articulo;
            this.autor = autor;

        }

        public void Generate()
        {
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

                        string archivo = azureService.download(articulo.Imagen);
                        
                        column.Item()
                        .AspectRatio(16 / 9f)
                        .Image(archivo);

                    string redSocial = autor.Redsocial;
                        column.Item()
                        .Text(autor.Redsocial)
                        .FontSize(18);

                        switch(redSocial)
                        {
                            case "Twitter":
                                break;
                            case "Instagram":
                                break;
                            case "Facebook":
                                break;
                            default:
                                break;
                        }
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


