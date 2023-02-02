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

namespace RestReviewV2.Servicios.PDF
{
    class PDFGenerator
    {
        private Articulo articulo;

        public PDFGenerator(Articulo articulo)
        {
            this.articulo = articulo;
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
                        /*
                        column.Item()
                        .AspectRatio(16 / 9f).Image(articulo.Imagen); */
                    
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
            }).GeneratePdf("output.pdf");
        }
    }
}


