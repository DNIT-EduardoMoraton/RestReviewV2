using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Mensajes.Difusion;
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



        // Commands

        public RelayCommand AbrirDialogoNuevaSeccionCommand { get; set; }
        public RelayCommand AbirDialogoNuevoAutorCommand { get; set; }
        public RelayCommand ExaminarImagenCommand { get; set; }

        // Services

        private NavegacionServicio servicioNavegacion;
        private ArticuloService servicioArticulos;
        private SeccionService servicioSeccion;
        private SaveService saveService;

        public ArticuloGestionarUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            servicioArticulos = new ArticuloService();
            servicioSeccion = new SeccionService();
            saveService = new SaveService();
            InicioPorDefecto();

            ManejadorCommands();
            ManejadorMensajes();
        }



        private void InicioPorDefecto()
        {
            SeccionLista = servicioSeccion.GetAll();
        }

        private void ManejadorCommands()
        {
            AbrirDialogoNuevaSeccionCommand = new RelayCommand(AbrirDialogoNuevaSeccionFun);
            AbirDialogoNuevoAutorCommand = new RelayCommand(AbirDialogoNuevoAutorFun);
            ExaminarImagenCommand = new RelayCommand(ExaminarImagenFun);
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
            ArticuloActual.Imagen = saveService.MostrarSaveDialog();
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
        }

    }


}

