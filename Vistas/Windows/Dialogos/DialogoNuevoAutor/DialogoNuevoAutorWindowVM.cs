using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevoAutor
{
    class DialogoNuevoAutorWindowVM : ObservableRecipient
    {
        private Autor autorActual;

        public Autor AutorActual
        {
            get { return autorActual; }
            set { SetProperty(ref autorActual, value); }
        }

        // Commands
        private RelayCommand crearCommand;

        // Servicios
        private AutoresService servicioAutores;
        public DialogoNuevoAutorWindowVM()
        {
            servicioAutores = new AutoresService();
            AutorActual = new Autor();

            ManejadorCommands();
        }

        private void ManejadorCommands()
        {
            throw new NotImplementedException();
        }

        public 
    }
}
