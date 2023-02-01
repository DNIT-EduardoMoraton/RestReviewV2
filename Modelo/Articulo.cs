
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


        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Lo unico que cambia aqui es que ahora nos guardamo una instancia de objeto de el autor ademas del indice

        private int autor;

        public int Autor
        {
            get { return autor; }
            set { SetProperty(ref autor, value); }
        }

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

        public Articulo(int id, int autor, int idSeccion, string texto, string titulo, string imagen, DateTime fechaPublicacionDate)
        {
            Id = id;
            Autor = autor;
            IdSeccion = idSeccion;
            Texto = texto;
            Titulo = titulo;
            Imagen = imagen;
            FechaPublicacion = fechaPublicacion;
        }
    }
}
