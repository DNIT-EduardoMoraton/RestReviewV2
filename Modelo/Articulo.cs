
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
            set { SetProperty(ref seccion, seccion); }
        }


        private Autor autor;

        public Autor Autor
        {
            get { return autor; }
            set { SetProperty(ref autor, value); }
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

    }
}
