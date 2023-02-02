using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
using GestorRestReview.Mensajes.Difusion;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using RestReviewV2.Mensajes.Difusion;
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

        private ArticuloEntity articuloActual;

        public ArticuloEntity ArticuloActual
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
            ListaArticulosActual = servicioArticulos.getAll();
        }

        private void ManejadorCommands()
        {
            AnyadirArticuloCommand = new RelayCommand(AnyadirArticuloCommandFun);



            WeakReferenceMessenger.Default.Register<AnyadirArticuloValueChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    ListaArticulosActual = servicioArticulos.getAll(); // No seria necesario ya que la vista se carga otra vez al navegar
                }
            });
        }

        // Commands functions

        private void AnyadirArticuloCommandFun()
        {
            WeakReferenceMessenger.Default.Send(new ArticuloNavValueChangedMesage(true));
        }


    }
}
