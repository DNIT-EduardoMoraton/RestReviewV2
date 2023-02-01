
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Modelo
{
    public class ArticuloEntity : ObservableObject
    {

        // Getters y Setters
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private int idAutor;

        public int IdAutor
        {
            get { return idAutor; }
            set { SetProperty(ref idAutor, value); }
        }

        private int idSeccion;

        public int IdSeccion
        {
            get { return idSeccion; }
            set { SetProperty(ref idSeccion, value); }
        }

        private string texto;

        public string Texto
        {
            get { return texto; }
            set { SetProperty(ref texto, value); }
        }

        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }

        public long fechaPublicacion;
        public long FechaPublicacion
        {
            get { return fechaPublicacion; }
            set { SetProperty(ref fechaPublicacion, value); }
        }

        public ArticuloEntity()
        {
        }

        public ArticuloEntity(int id, int idAutor, int idSeccion, string texto, string titulo, string imagen, long fechaPublicacion)
        {
            Id = id;
            IdAutor = idAutor;
            IdSeccion = idSeccion;
            Texto = texto;
            Titulo = titulo;
            Imagen = imagen;
            FechaPublicacion = fechaPublicacion;
        }
    }
}
