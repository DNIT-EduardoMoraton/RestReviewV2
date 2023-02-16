using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Servicios.GuardarHTML;
using RestReviewV2.Servicios.Moderacion;
using RestReviewV2.Servicios.PDF;
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
        public object ModeratorService { get; private set; }

        // Services

        private NavegacionServicio servicioNavegacion;
        private GenerarHTML htmlService;
        private LoadSaveDialogService saveService;
        private AlertaServicio servicioAlerta;

        public HomeWebPreviewUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            htmlService = new GenerarHTML();
            saveService = new LoadSaveDialogService();
            servicioAlerta = new AlertaServicio();
            InicioPorDefectoAsync();


            ManejadorCommands();
        }

        private async Task InicioPorDefectoAsync()
        {

            //servicioAlerta.MessageBoxError(new Moderator().ModerarTexto("hijo de puta"));
            HTMLRuta = "file:///" + htmlService.GetPreview(); // Aqui solamente poner la ruta del archivo temporal para la pagina web 
            //HTMLRuta = "www.google.es";

            //Servicio Articulo(Pruebas)
            ArticuloService articulosService = new ArticuloService();

           

            ModeratorService client = new ModeratorService();
            var response = await client.AddCustomListTerm(new CustomListTerm { ListId = "your-list-id", Term = "your-term", Language = "en" });


        }

        private void ManejadorCommands()
        {
            GuardarHTMLCommand = new RelayCommand(GuardarHTMLFun);
        }

        // Commands Funcs

        private void GuardarHTMLFun()
        {
            string path = saveService.MostrarSaveDialogHTML();
            if (path == null)
            {
                servicioAlerta.MessageBoxError("no se ha seleccionado nada");
            }
            htmlService.SaveTo(path);
        }
    }
}
