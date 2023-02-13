using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using GestorRestReview.Servicios;
using System.Windows.Controls;

namespace GestorRestReview.Vistas.UserControls.Home
{
    class HomeUserControlVM : ObservableRecipient
    {
        private UserControl actualUserControl;
        private BDRevista bd;

        public UserControl ActualUserControl
        {
            get { return actualUserControl; }
            set { SetProperty(ref actualUserControl, value); }
        }

        // Commands

        public RelayCommand ModeracionCommand { get; set; }
        public RelayCommand AutorCommand { get; set; }
        public RelayCommand ArticuloComand { get; set; }
        public RelayCommand HomeWebPreview { get; set; }

        // Services

        private NavegacionServicio servicioNavegacion;

        public HomeUserControlVM()
        {
            bd = new BDRevista();
            bd.inicializar();

            servicioNavegacion = new NavegacionServicio();
            InicioPorDefecto();


            ManejadorCommands();
        }

        private void InicioPorDefecto()
        {
            ActualUserControl = servicioNavegacion.IrHomeWebPreviewUserControl();
           
        }

        private void ManejadorCommands()
        {
            AutorCommand = new RelayCommand(AutoresFun);
            ModeracionCommand = new RelayCommand(ModeracionFun);
            ArticuloComand = new RelayCommand(ArticuloCommandFun);
            HomeWebPreview = new RelayCommand(HomeWebPreviewFun);
        }

        // Commands Funcs

        private void ArticuloCommandFun()
        {
            ActualUserControl = servicioNavegacion.IrArticulosUserControl(); // ver que no se tiene que eliminar
        }

        private void HomeWebPreviewFun()
        {
            ActualUserControl = servicioNavegacion.IrHomeWebPreviewUserControl();
        }

        private void ModeracionFun()
        {
            ActualUserControl = servicioNavegacion.IrModeracionUserControl();
        }

        private void AutoresFun()
        {
            ActualUserControl = servicioNavegacion.IrAutoresUserControl();
        }
    }
}
