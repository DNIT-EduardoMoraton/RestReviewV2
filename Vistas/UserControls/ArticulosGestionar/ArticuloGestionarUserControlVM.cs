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
using RestReviewV2.Servicios.Moderacion;
using RestReviewV2.Servicios.Moderacion.clases;
using RestReviewV2.Servicios.PDF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private ObservableCollection<ListaModeracion> listasModeracion;
        public ObservableCollection<ListaModeracion> ListasModeracion
        {
            get { return listasModeracion; }
            set { SetProperty(ref listasModeracion, value); }
        }

        private ListaModeracion listaModeracionActual;

        public ListaModeracion ListaModeracionActual
        {
            get { return listaModeracionActual; }
            set { SetProperty(ref listaModeracionActual, value); }
        }


        // Commands

        public RelayCommand AbrirDialogoNuevaSeccionCommand { get; set; }
        public RelayCommand AbirDialogoNuevoAutorCommand { get; set; }
        public RelayCommand ExaminarImagenCommand { get; set; }
        public RelayCommand GuardarArticuloCommand { get; set; }
        public RelayCommand ValidateCommand { get; set; }
        public RelayCommand UploadCommand { get; set; }

        

        // Services

        private NavegacionServicio servicioNavegacion;
        private ArticuloService servicioArticulos;
        private AutoresService servicioAutores;
        private SeccionService servicioSeccion;
        private LoadSaveDialogService saveService;
        private BlobService servicioBlob;
        private AlertaServicio servicioAlerta;
        private PDFService servicioPDF;
        private ModeratorService servicioModeracion;

        public ArticuloGestionarUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            servicioArticulos = new ArticuloService();
            servicioAutores = new AutoresService();
            servicioPDF = new PDFService();
            servicioSeccion = new SeccionService();
            saveService = new LoadSaveDialogService();
            servicioBlob = new BlobService();
            servicioAlerta = new AlertaServicio();

            servicioModeracion = new ModeratorService();

            InicioPorDefecto();

            ManejadorCommands();
            ManejadorMensajes();
        }



        private void InicioPorDefecto()
        {
            
            SeccionLista = servicioSeccion.GetAll();
            AutorLista = servicioAutores.GetAll();
            ArticuloActual = WeakReferenceMessenger.Default.Send<ArticuloActualListaRequestMessage>();
            if (ArticuloActual==null)
                ArticuloActual = new Articulo();
            UpdateLists();

        }

        private void ManejadorCommands()
        {
            AbrirDialogoNuevaSeccionCommand = new RelayCommand(AbrirDialogoNuevaSeccionFun);
            AbirDialogoNuevoAutorCommand = new RelayCommand(AbirDialogoNuevoAutorFun);
            ExaminarImagenCommand = new RelayCommand(ExaminarImagenFun);
            GuardarArticuloCommand = new RelayCommand(GuardarArticuloFun);
            ValidateCommand = new RelayCommand(ValidateFun);
            UploadCommand = new RelayCommand(UploadFun);
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

            if (ArticuloActual.Url == null)
                ArticuloActual.Url = "NULL"; // Sustituir por subida en articulo



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

        private void ValidateFun()
        {
            string palabrasJuntas = "";
            Task t = Task.Run(async () =>
            {
                List<string> malasPalabras = null;
                if (ListaModeracionActual.Id == null)
                {
                    malasPalabras = servicioModeracion.Moderate(ArticuloActual.Texto, null).Result;
                } else
                {
                    malasPalabras = servicioModeracion.Moderate(ArticuloActual.Texto, ListaModeracionActual.Id).Result;
                }     

           
                foreach (string p in malasPalabras)
                {
                    palabrasJuntas += p + "/";
                }
                
            });
            Thread.Sleep(2000);
            servicioAlerta.MessageBoxCambio(palabrasJuntas);

        }

        public void UploadFun()
        {
            if (ArticuloActual.Imagen==null)
            {
                return;
                servicioAlerta.MessageBoxError("No has seleccionado una imagen");
            }
            //Genera PDF
            string pdfRutaLocal = servicioPDF.Generate(ArticuloActual);
            //FileStream pdfFs = new FileStream(pdfRutaLocal, FileMode.Open);
            //Sube el PDF a Azure
            string rutaAzure = servicioBlob.upload(pdfRutaLocal);
            //Borra de local el PDF
            File.Delete(pdfRutaLocal);
            //Asigna la url de Azure del pdf a la propiedad del Articulo
            ArticuloActual.Url = rutaAzure;

            
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

        private async Task UpdateLists()
        {
            ListasModeracion = new ObservableCollection<ListaModeracion>();
            Task t = Task.Run(async () =>
            {
                ListasModeracion = servicioModeracion.GetAllLists().Result;

                foreach (var item in ListasModeracion)
                {
                    item.ListaPalabras = await servicioModeracion.GetTerms(item.Id);
                }
                ListasModeracion.Add(new ListaModeracion(null, null, "Azure por defecto"));

            });
            
        }

    }


}

