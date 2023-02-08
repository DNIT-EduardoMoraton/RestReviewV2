using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
using GestorRestReview.Mensajes.Difusion;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Mensajes.Difusion;
using RestReviewV2.Mensajes.Solicitud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Vistas.UserControls.ArticulosLista
{
    class ArticulosListaUserControlVM :  ObservableRecipient
    {
        // Getters y Setters

        private Articulo articuloActual;

        public Articulo ArticuloActual
        {
            get { return articuloActual; }
            set { SetProperty(ref articuloActual, value); }
        }


        private ObservableCollection<Articulo> listaArticulosActual;

        public ObservableCollection<Articulo> ListaArticulosActual
        {
            get { return listaArticulosActual; }
            set { SetProperty(ref listaArticulosActual, value); }
        }


        // Commands

        public RelayCommand AnyadirArticuloCommand { get; set; }
        public RelayCommand EditarArticuloCommand { get; set; }
        public RelayCommand BorrarArticuloCommand { get; set; }


        // Services

        private NavegacionServicio servicioNavegacion;
        private ArticuloService servicioArticulos;

        public ArticulosListaUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            servicioArticulos = new ArticuloService();
            InicioPorDefecto();

            ManejadorCommands();
        }


        private void InicioPorDefecto()
        {
            ListaArticulosActual = servicioArticulos.GetAll();
        }

        private void ManejadorCommands()
        {
            AnyadirArticuloCommand = new RelayCommand(AnyadirArticuloCommandFun);
            BorrarArticuloCommand = new RelayCommand(BorrarArticuloCommandFun);
            EditarArticuloCommand = new RelayCommand(EditarArticuloCommandFun);

            WeakReferenceMessenger.Default.Register<AnyadirArticuloValueChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    ListaArticulosActual = servicioArticulos.GetAll(); // No seria necesario ya que la vista se carga otra vez al navegar
                }
            });
        }

        // Commands functions

        private void AnyadirArticuloCommandFun() // Quiza reducir el codigo y dejar solamente un comando para los 2 botones
        {
            WeakReferenceMessenger.Default.Register<ArticulosListaUserControlVM, ArticuloActualListaRequestMessage>
            (this, (r, m) => {
                m.Reply(r.ArticuloActual);
            });
            WeakReferenceMessenger.Default.Send(new ArticuloNavValueChangedMesage(true));
        }

        private void BorrarArticuloCommandFun()
        {
            servicioArticulos.Delete(ArticuloActual);
            ListaArticulosActual = servicioArticulos.GetAll();
        }

        private void EditarArticuloCommandFun()
        {
            WeakReferenceMessenger.Default.Register<ArticulosListaUserControlVM, ArticuloActualListaRequestMessage>
                (this, (r, m) => {
                    if (!m.HasReceivedResponse)
                        m.Reply(r.ArticuloActual);
            });
            WeakReferenceMessenger.Default.Send(new ArticuloNavValueChangedMesage(true));
        }

    }
}
