﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorRestReview.BD;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevaSeccion
{
    class DialogoNuevaSeccionVM : ObservableObject
    {
        public RelayCommand crearCommand;

        private Seccion seccionActual;

        public Seccion SeccionActual
        {
            get { return seccionActual; }
            set { SetProperty(ref seccionActual, value); }
        }




        private AlertaServicio servicioAlerta;
        private SeccionService servicioSeccion;

        public DialogoNuevaSeccionVM()
        {
            servicioAlerta = new AlertaServicio();
            servicioSeccion = new SeccionService();

            manejadorCommands();
            InicioPorDefecto();
        }

        private void InicioPorDefecto()
        {
            SeccionActual = new Seccion();
        }


        private void manejadorCommands()
        {
            crearCommand = new RelayCommand(Crear);
        }

        public void Crear()
        {
            if (SeccionActual.Nombre==null)
            {
                servicioAlerta.MessageBoxCambio("El campo nombre no puede estar vacio");
                return;
            }
            servicioSeccion.Add(SeccionActual);
        }
        
    }
}
