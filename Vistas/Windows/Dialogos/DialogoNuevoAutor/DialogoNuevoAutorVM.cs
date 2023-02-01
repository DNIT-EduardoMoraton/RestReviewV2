using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevoAutor
{
    class DialogoNuevoAutorVM
    {
        public RelayCommand crearCommand;
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public AutoresService seccion;

        public DialogoNuevoAutorVM()
        {
            seccion = new SeccionService();
            crearCommand = new RelayCommand(Crear);

        }

        public void Crear()
        {
            seccion.Add(new Autor(0, Nombre, Descripcion));
        }
    }
}
