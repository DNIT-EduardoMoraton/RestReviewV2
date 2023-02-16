using GestorRestReview.Vistas.UserControls.Articulos;
using GestorRestReview.Vistas.UserControls.ArticulosGestionar;
using GestorRestReview.Vistas.UserControls.ArticulosLista;
using GestorRestReview.Vistas.UserControls.Autores;
using GestorRestReview.Vistas.UserControls.Home;
using GestorRestReview.Vistas.UserControls.HomeWebPreview;
using GestorRestReview.Vistas.Windows.Dialogos.DialogoNuevaSeccion;
using RestReviewV2.Vistas.UserControls.Moderacion;
using RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Servicios
{
    class NavegacionServicio
    {


        private ArticulosListaUserControl listaArticulosUserControl;
        private AutoresUserControl autoresUserControl;
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
            if (listaArticulosUserControl == null)
                listaArticulosUserControl = new ArticulosListaUserControl();
            return listaArticulosUserControl;
        }


        // Autores

        public AutoresUserControl IrAutoresUserControl()
        {
            if (autoresUserControl == null)
            {
                autoresUserControl = new AutoresUserControl();
            }
            return autoresUserControl;
        }


        // Moderacion

        public ModeracionUserControl IrModeracionUserControl()
        {
            return new ModeracionUserControl();
        }


        // Dialogos

        public bool? AbreDialogoNuevaSeccionWindow()
        {
            DialogoNuevaSeccionWindow w = new DialogoNuevaSeccionWindow();
            return w.ShowDialog();
            
        }

        public bool? AbreDialogoNuevoAutor()
        {
            DialogoNuevoAutorWindow w = new DialogoNuevoAutorWindow();
            return w.ShowDialog(); 
        }

    }
}
