using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevaSeccion
{
    class DialogoNuevaSeccionVM : ObservableObject
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


        public SeccionService seccion;

        public DialogoNuevaSeccionVM()
        {
            seccion = new SeccionService();
            crearCommand = new RelayCommand(Crear);
            
        }

        public void Crear()
        {
            seccion.Add(new Seccion(0,Nombre, Descripcion));
        }
        
    }
}
