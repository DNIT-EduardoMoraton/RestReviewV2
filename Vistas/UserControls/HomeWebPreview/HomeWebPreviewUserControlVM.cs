﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.Servicios;
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

        public RelayCommand ArticuloComand { get; set; } // Son solo muestras no son de aqui
        public RelayCommand HomeWebPreview { get; set; }

        // Services

        private NavegacionServicio servicioNavegacion;

        public HomeWebPreviewUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            InicioPorDefecto();


            ManejadorCommands();
        }

        private void InicioPorDefecto()
        {
            GenerarHTML generar = new GenerarHTML();
            generar.GenerateHTML();
            HTMLRuta = "file:///" + Path.GetFullPath("./Assets/web/webplantilla.html"); // Aqui solamente poner la ruta del archivo temporal para la pagina web 

        }

        private void ManejadorCommands()
        {

        }

        // Commands Funcs

        private void HomeWebPreviewFun()
        {

        }
    }
}
