using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.Servicios;
using RestReviewV2.Servicios.GuardarHTML;
using RestReviewV2.Servicios.Moderacion;
using RestReviewV2.Servicios.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Vistas.UserControls.HomeWebPreview
{
    class HomeWebPreviewUserControlVM : ObservableRecipient
    {
        private string hTMLRuta;

        public string HTMLRuta
        {
            get { return hTMLRuta; }
            set { SetProperty(ref hTMLRuta, value); }
        }

        // Commands

        public RelayCommand GuardarHTMLCommand { get; set; } // Son solo muestras no son de aqui

        // Services

        private NavegacionServicio servicioNavegacion;
        private GenerarHTML htmlService;
        private SaveService saveService;
        private AlertaServicio servicioAlerta;

        public HomeWebPreviewUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            htmlService = new GenerarHTML();
            saveService = new SaveService();
            servicioAlerta = new AlertaServicio();
            InicioPorDefecto();


            ManejadorCommands();
        }

        private void InicioPorDefecto()
        {
            servicioAlerta.MessageBoxError(new Moderator().ModerarTexto("hijo de puta"));
            htmlService.GenerateHTML();
            HTMLRuta = "file:///" + Path.GetFullPath(htmlService.getPreview()); // Aqui solamente poner la ruta del archivo temporal para la pagina web 

        }

        private void ManejadorCommands()
        {
            GuardarHTMLCommand = new RelayCommand(GuardarHTMLFun);
        }

        // Commands Funcs

        private void GuardarHTMLFun()
        {
            string path = saveService.MostrarSaveDialog();
            if (path == null)
            {
                servicioAlerta.MessageBoxError("no se ha seleccionado nada");
            }
            htmlService.saveTo(path);
        }
    }
}
