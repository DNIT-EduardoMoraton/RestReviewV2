using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using System;
using System.Collections.Generic;
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


        // Commands

        public RelayCommand AbrirDialogoNuevaSeccionCommand { get; set; }

        // Services

        private NavegacionServicio servicioNavegacion;
        private ArticuloService servicioArticulos;

        public ArticuloGestionarUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            servicioArticulos = new ArticuloService();
            InicioPorDefecto();

            ManejadorCommands();
        }


        private void InicioPorDefecto()
        {

        }

        private void ManejadorCommands()
        {
            AbrirDialogoNuevaSeccionCommand = new RelayCommand(AbrirDialogoNuevaSeccionFun);
        }

        // Commands functions

        private void AbrirDialogoNuevaSeccionFun()
        {
            servicioNavegacion.AbreDialogoNuevaSeccionWindow();
        }


    }


}

