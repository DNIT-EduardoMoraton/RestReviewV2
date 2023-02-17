using GestorRestReview.Vistas.UserControls.Articulos;
using GestorRestReview.Vistas.UserControls.ArticulosGestionar;
using GestorRestReview.Vistas.UserControls.ArticulosLista;
using GestorRestReview.Vistas.UserControls.Autores;
using GestorRestReview.Vistas.UserControls.Home;
using GestorRestReview.Vistas.UserControls.HomeWebPreview;
using GestorRestReview.Vistas.Windows.Dialogos.DialogoNuevaSeccion;
using RestReviewV2.Vistas.UserControls.AutoresGestionar;
using RestReviewV2.Vistas.UserControls.AutoresLista;
using RestReviewV2.Vistas.UserControls.Moderacion;
using RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestorRestReview.Servicios
{

    /// <summary>
    /// Clase que provee servicios de navegación y diálogos para la aplicación.
    /// </summary>
    class NavegacionServicio
    {


        private ArticulosListaUserControl listaArticulosUserControl;
        private AutoresUserControl autoresUserControl;
        private AutoresListaUserControl listaAutoresUserControl;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public NavegacionServicio()
        {
            
        }


        // Home --------------------------------------------------------------

        /// <summary>
        /// Muestra la vista HomeUserControl.
        /// </summary>
        /// <returns>Un objeto de tipo HomeUserControl.</returns>
        public HomeUserControl IrHomeUSerControl() // Usado desde main window
        {
            return new HomeUserControl();
        }


        /// <summary>
        /// Muestra la vista HomeWebPreviewUserControl.
        /// </summary>
        /// <returns>Un objeto de tipo HomeWebPreviewUserControl.</returns>
        public HomeWebPreviewUserControl IrHomeWebPreviewUserControl()
        {
            return new HomeWebPreviewUserControl();
        }

        // Articulos ----------------------------------------------------

        /// <summary>
        /// Muestra la vista ArticulosUserControl.
        /// </summary>
        /// <returns>Un objeto de tipo ArticulosUserControl.</returns>
        public ArticulosUserControl IrArticulosUserControl()
        {
            return new ArticulosUserControl();
        }

        /// <summary>
        /// Muestra la vista ArticuloGestionarUserControl.
        /// </summary>
        /// <returns>Un objeto de tipo ArticuloGestionarUserControl.</returns>
        public ArticuloGestionarUserControl IrArticulosGestionarUserControl()
        {
            return new ArticuloGestionarUserControl();
        }

        /// <summary>
        /// Muestra la vista ArticulosListaUserControl. Si ya está creada la vista, devuelve la instancia existente.
        /// </summary>
        /// <returns>Un objeto de tipo ArticulosListaUserControl.</returns>
        public ArticulosListaUserControl IrArticulosListaUserControl()
        {
            if (listaArticulosUserControl == null)
                listaArticulosUserControl = new ArticulosListaUserControl();
            return listaArticulosUserControl;
        }


        // Autores


        /// <summary>
        /// Muestra la vista AutoresUserControl. Si ya está creada la vista, devuelve la instancia existente.
        /// </summary>
        /// <returns>Un objeto de tipo AutoresUserControl.</returns>
        /// 
        public AutoresUserControl IrAutoresUserControl()
        {
            return new AutoresUserControl();
        }
        public AnyadirAutorUserControl IrAnyadirAutorUserControl()
        {
            return new AnyadirAutorUserControl();
        }

        public AutoresListaUserControl IrAutoresListaUserControl()
        {
            if (listaAutoresUserControl == null)
                listaAutoresUserControl = new AutoresListaUserControl();
            return listaAutoresUserControl;
        }


        // Moderacion

        /// <summary>
        /// Muestra la vista ModeracionUserControl.
        /// </summary>
        /// <returns>Un objeto de tipo ModeracionUserControl.</returns>
        public ModeracionUserControl IrModeracionUserControl()
        {
            return new ModeracionUserControl();
        }


        // Dialogos

        /// <summary>
        /// Abre el diálogo DialogoNuevaSeccionWindow.
        /// </summary>
        /// <returns>Un valor booleano que indica si el usuario ha pulsado Aceptar o Cancelar.</returns>
        public bool? AbreDialogoNuevaSeccionWindow()
        {
            DialogoNuevaSeccionWindow w = new DialogoNuevaSeccionWindow();
            return w.ShowDialog();
            
        }

        /// <summary>
        /// Abre el diálogo DialogoNuevoAutor.
        /// </summary>
        /// <returns>Un valor booleano que indica si el usuario ha pulsado Aceptar o Cancelar.</returns>
        public bool? AbreDialogoNuevoAutor()
        {
            DialogoNuevoAutorWindow w = new DialogoNuevoAutorWindow();
            return w.ShowDialog(); 
        }

    }
}
