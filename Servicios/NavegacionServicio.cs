using GestorRestReview.Vistas.UserControls.Articulos;
using GestorRestReview.Vistas.UserControls.ArticulosGestionar;
using GestorRestReview.Vistas.UserControls.ArticulosLista;
using GestorRestReview.Vistas.UserControls.Home;
using GestorRestReview.Vistas.UserControls.HomeWebPreview;
using GestorRestReview.Vistas.Windows.Dialogos.DialogoNuevaSeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Servicios
{
    class NavegacionServicio
    {
        public NavegacionServicio()
        {
            
        }


        // Home --------------------------------------------------------------
        public HomeUserControl IrHomeUSerControl() // Usado desde main window
        {
            return new HomeUserControl();
        }

        public HomeWebPreviewUserControl IrHomeWebPreviewUserControl()
        {
            return new HomeWebPreviewUserControl();
        }

        // Articulos ----------------------------------------------------
        public ArticulosUserControl IrArticulosUserControl()
        {
            return new ArticulosUserControl();
        }
        
        public ArticuloGestionarUserControl IrArticulosGestionarUserControl()
        {
            return new ArticuloGestionarUserControl();
        }

        public ArticulosListaUserControl IrArticulosListaUserControl()
        {
            return new ArticulosListaUserControl();
        }



        // Dialogos

        public bool? AbreDialogoNuevaSeccionWindow()
        {
            DialogoNuevaSeccionWindow w = new DialogoNuevaSeccionWindow();
            return w.ShowDialog();
            
        }

    }
}
