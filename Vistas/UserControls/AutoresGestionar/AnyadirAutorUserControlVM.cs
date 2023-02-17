using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Mensajes.Difusion;
using RestReviewV2.Mensajes.Solicitud;
using RestReviewV2.Servicios;
using RestReviewV2.Servicios.BD;
using RestReviewV2.Servicios.GuardarHTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Vistas.UserControls.AutoresGestionar
{
    class AnyadirAutorUserControlVM : ObservableRecipient
    {
        private Autor autorActual;

        public Autor AutorActual
        {
            get { return autorActual; }
            set { SetProperty(ref autorActual, value); }
        }

        private List<string> rSSList;

        public List<string> RSSList
        {
            get { return rSSList; }
            set { SetProperty(ref rSSList, value); }
        }


        // Commands
        public RelayCommand CrearCommand { get; set; }
        public RelayCommand OpenImageCommand { get; set; }
        public RelayCommand GuardarAutorCommand { get; set; }


        // Servicios
        private AutoresService servicioAutores;
        private LoadSaveDialogService loadsaveService;
        private RedesSocialesServicio redesServicio;
        private AlertaServicio alertaServicio;
        private BlobService blobService;
        private AlertaServicio servicioAlerta;
        public AnyadirAutorUserControlVM()
        {
            servicioAutores = new AutoresService();
            loadsaveService = new LoadSaveDialogService();
            redesServicio = new RedesSocialesServicio();
            blobService = new BlobService();
            AutorActual = new Autor();
            alertaServicio = new AlertaServicio();
            servicioAlerta = new AlertaServicio();

            InicioPorDefecto();
            RSSList = redesServicio.List;
            ManejadorCommands();
        }

        private void InicioPorDefecto()
        {

            AutorActual = WeakReferenceMessenger.Default.Send<AutorActualListaRequestMessage>();
            if (AutorActual == null)
                AutorActual = new Autor();

        }

        private void ManejadorCommands()
        {
            CrearCommand = new RelayCommand(createFun);
            OpenImageCommand = new RelayCommand(OpenImageFun);
            GuardarAutorCommand = new RelayCommand(GuardarAutorFun);
        }

        private void GuardarAutorFun()
        {
            if (servicioAutores.add(autorActual))
            {
                servicioAlerta.MessageBoxError("Se ha guardado");
                WeakReferenceMessenger.Default.Send(new AutorNavValueChangedMessage(false));
                WeakReferenceMessenger.Default.Send(new AnyadirAutorValueChangedMessage(true));
                return;
            }
            servicioAlerta.MessageBoxError("No se ha creado");
        }

        public void createFun()
        {
            if (AutorActual.Imagen == null) // Lanzar mensaje
            {
                alertaServicio.MessageBoxError("NO IMAGEN");
                return;
            }
            if (AutorActual.NickName == null)
            {
                alertaServicio.MessageBoxError("NO Nich");
                return;
            }
            if (AutorActual.Redsocial == null)
            {
                alertaServicio.MessageBoxError("NO Red");
                return;
            }


            AutorActual.Imagen = blobService.upload(AutorActual.Imagen);
            servicioAutores.add(AutorActual);

            WeakReferenceMessenger.Default.Send(new AnyadirAutorValueChangedMessage(true));
        }

        private void OpenImageFun()
        {
            string path = loadsaveService.MostrarOpenDialogImages();

            if (path == null)
            {
                return;
            }

            AutorActual.Imagen = path;
        }
    }
}
