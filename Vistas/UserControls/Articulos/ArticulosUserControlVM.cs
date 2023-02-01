
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.Mensajes.Difusion;
using GestorRestReview.Servicios;

using System.Windows.Controls;

namespace GestorRestReview.Vistas.UserControls.Articulos
{
    class ArticulosUserControlVM : ObservableRecipient
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


        public ArticulosUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            InicioPorDefecto();


            ManejadorMensajes();
        }


        private void InicioPorDefecto()
        {
            CurrUserControl = servicioNavegacion.IrArticulosListaUserControl();
        }


        private void ManejadorMensajes()
        {
            WeakReferenceMessenger.Default.Register<ArticuloNavValueChangedMesage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    CurrUserControl = servicioNavegacion.IrArticulosGestionarUserControl();
                }
            });
        }
    }
}
