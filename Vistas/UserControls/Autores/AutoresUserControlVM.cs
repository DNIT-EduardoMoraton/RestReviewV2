using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Mensajes.Difusion;
using RestReviewV2.Mensajes.Solicitud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestorRestReview.Vistas.UserControls.Autores
{
    class AutoresUserControlVM : ObservableRecipient
    {
        private UserControl currUserControl;

        public UserControl CurrUserControl
        {
            get { return currUserControl; }
            set { SetProperty(ref currUserControl, value); }
        }

        // Commands



        // Services

        private NavegacionServicio servicioNavegacion;


        public AutoresUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            InicioPorDefecto();


            ManejadorMensajes();
        }


        private void InicioPorDefecto()
        {
            CurrUserControl = servicioNavegacion.IrAutoresListaUserControl();
        }


        private void ManejadorMensajes()
        {
            WeakReferenceMessenger.Default.Register<AutorNavValueChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    CurrUserControl = servicioNavegacion.IrAnyadirAutorUserControl();
                }
                else
                {
                    CurrUserControl = servicioNavegacion.IrAutoresListaUserControl();
                }
            });
        }
    }
}
