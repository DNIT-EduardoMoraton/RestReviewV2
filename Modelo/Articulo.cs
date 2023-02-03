
using CommunityToolkit.Mvvm.ComponentModel;
using GestorRestReview.BD.Convertidores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Modelo
{
    class Articulo :  ArticuloEntity
    {


        private Seccion seccion;

        public Seccion Seccion
        {
            get { return seccion; }
            set { SetProperty(ref seccion, value); }
        }


        private Autor autor;

        public Autor Autor
        {
            get { return autor; }
            set { SetProperty(ref autor, value); }
        }

        private bool isPublicado;

        public bool IsPublicado
        {
            get { return this.Url != "NULL"; }
            set { SetProperty(ref isPublicado, value); }
        }



        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Conversiones de fechas importantes

        public DateTime fechaPublicacionDate;



        public DateTime FechaPublicacionDate
        {
            get { return epoch.AddSeconds(this.FechaPublicacion);  }
            set {

                this.FechaPublicacion = (long)(value.ToUniversalTime() - epoch).TotalSeconds;
                SetProperty(ref fechaPublicacionDate, value); 
            }
        }


        

        public Articulo()
        {
        }

        public Articulo(int id, int idAutor, int idSeccion, string texto, string titulo, string imagen, long fechaPublicacion, string url) : base(id, idAutor, idSeccion, texto, titulo, imagen, fechaPublicacion, url)
        {
        }

        public Articulo(ArticuloEntity art)
        {
            this.Id = art.Id;
            this.IdAutor = art.IdAutor;
            this.IdSeccion = art.IdSeccion;
            this.Texto = art.Texto;
            this.Titulo = art.Titulo;
            this.Imagen = art.Imagen;
            this.FechaPublicacion = art.FechaPublicacion;
            this.Url = art.Url;
        }
    }
}
