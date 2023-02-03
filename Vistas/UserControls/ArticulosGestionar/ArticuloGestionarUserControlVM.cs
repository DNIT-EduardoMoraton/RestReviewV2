using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
using GestorRestReview.Mensajes.Difusion;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Mensajes.Difusion;
using RestReviewV2.Mensajes.Solicitud;
using RestReviewV2.Servicios.BD;
using RestReviewV2.Servicios.GuardarHTML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Vistas.UserControls.ArticulosGestionar
{
    class ArticuloGestionarUserControlVM : ObservableRecipient
    {

        private Articulo articuloActual;

        public Articulo ArticuloActual
        {
            get { return articuloActual; }
            set { SetProperty(ref articuloActual, value); }
        }

        private ObservableCollection<Seccion> seccionLista;

        public ObservableCollection<Seccion> SeccionLista
        {
            get { return seccionLista; }
            set { SetProperty(ref seccionLista, value); }
        }

        private ObservableCollection<Autor> autorLista;

        public ObservableCollection<Autor> AutorLista
        {
            get { return autorLista; }
            set { SetProperty(ref autorLista, value); }
        }


        // Commands

        public RelayCommand AbrirDialogoNuevaSeccionCommand { get; set; }
        public RelayCommand AbirDialogoNuevoAutorCommand { get; set; }
        public RelayCommand ExaminarImagenCommand { get; set; }
        public RelayCommand GuardarArticuloCommand { get; set; }
 

        // Services

        private NavegacionServicio servicioNavegacion;
        private ArticuloService servicioArticulos;
        private AutoresService servicioAutores;
        private SeccionService servicioSeccion;
        private LoadSaveDialogService saveService;
        private BlobService servicioBlob;
        private AlertaServicio servicioAlerta;

        public ArticuloGestionarUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            servicioArticulos = new ArticuloService();
            servicioAutores = new AutoresService();

            servicioSeccion = new SeccionService();
            saveService = new LoadSaveDialogService();
            servicioBlob = new BlobService();
            servicioAlerta = new AlertaServicio();

            InicioPorDefecto();

            ManejadorCommands();
            ManejadorMensajes();
        }



        private void InicioPorDefecto()
        {
            ArticuloActual = new Articulo();
            SeccionLista = servicioSeccion.GetAll();
            AutorLista = servicioAutores.GetAll();
            //ArticuloActual = WeakReferenceMessenger.Default.Send<ArticuloActualListaRequestMessage>();
        }

        private void ManejadorCommands()
        {
            AbrirDialogoNuevaSeccionCommand = new RelayCommand(AbrirDialogoNuevaSeccionFun);
            AbirDialogoNuevoAutorCommand = new RelayCommand(AbirDialogoNuevoAutorFun);
            ExaminarImagenCommand = new RelayCommand(ExaminarImagenFun);
            GuardarArticuloCommand = new RelayCommand(GuardarArticuloFun);
        }

        // Commands functions

        private void AbrirDialogoNuevaSeccionFun()
        {
            servicioNavegacion.AbreDialogoNuevaSeccionWindow();
        }

        private void AbirDialogoNuevoAutorFun()
        {
            servicioNavegacion.AbreDialogoNuevoAutor();
        }

        private void ExaminarImagenFun()
        {
            string path = saveService.MostrarOpenDialogImages();
            if (path == null)
            {
                return;
            }
            ArticuloActual.Imagen = path;

        }

        private void GuardarArticuloFun()
        {
            // MODERAR VA AQUI
            // Comprobar que todo articulo actual esta bien
            ArticuloActual.Url = "NULL";

            ArticuloActual.Imagen = servicioBlob.upload(ArticuloActual.Imagen);
            
            if (servicioArticulos.add(ArticuloActual))
            {
                servicioAlerta.MessageBoxError("Se ha guardado");
                WeakReferenceMessenger.Default.Send(new ArticuloNavValueChangedMesage(false));
                WeakReferenceMessenger.Default.Send(new AnyadirArticuloValueChangedMessage(true));
                return;
            }
            servicioAlerta.MessageBoxError("No se ha creado");
        }


        private void ManejadorMensajes()
        {
            WeakReferenceMessenger.Default.Register<AnyadirSeccionValueChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    SeccionLista = servicioSeccion.GetAll();
                }
            });
            WeakReferenceMessenger.Default.Register<AnyadirAutorValueChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    AutorLista = servicioAutores.GetAll();
                }
            });
        }

    }


}

