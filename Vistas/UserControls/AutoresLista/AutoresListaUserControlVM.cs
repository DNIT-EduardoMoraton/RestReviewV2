using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorRestReview.BD;
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

namespace RestReviewV2.Vistas.UserControls.AutoresLista
{
    class AutoresListaUserControlVM : ObservableRecipient
    {
        private Autor autorActual;

        public Autor AutorActual
        {
            get { return autorActual; }
            set { autorActual = value; }
        }

        private ObservableCollection<Autor> listaAutoresActual;

        public ObservableCollection<Autor> ListaAutoresActual
        {
            get { return listaAutoresActual; }
            set { listaAutoresActual = value; }
        }

        public RelayCommand AnyadirAutorCommand { get; set; }
        public RelayCommand EditarAutorCommand { get; set; }
        public RelayCommand BorrarAutorCommand { get; set; }

        private NavegacionServicio servicioNavegacion;
        private AutoresService servicioAutores;

        public AutoresListaUserControlVM()
        {
            servicioNavegacion = new NavegacionServicio();
            servicioAutores = new AutoresService();
            InicioPorDefecto();

            ManejadorCommands();
        }

        private void InicioPorDefecto()
        {
            ListaAutoresActual = servicioAutores.GetAll();
        }

        private void ManejadorCommands()
        {
            AnyadirAutorCommand = new RelayCommand(AnyadirAutorCommandFun);
            EditarAutorCommand = new RelayCommand(EditarAutorCommandFun);
            BorrarAutorCommand = new RelayCommand(BorrarAutorCommandFun); 

            WeakReferenceMessenger.Default.Register<AnyadirAutorValueChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    ListaAutoresActual = servicioAutores.GetAll();
                }
            });
            WeakReferenceMessenger.Default.Register<AutoresListaUserControlVM, AutorActualListaRequestMessage>
            (this, (r, m) => {
                if (!m.HasReceivedResponse)
                    m.Reply(r.AutorActual);
            });
        }

        private void EditarAutorCommandFun()
        {
            WeakReferenceMessenger.Default.Send(new AutorNavValueChangedMessage(true));
        }

        private void BorrarAutorCommandFun()
        {
            servicioAutores.Delete(AutorActual);
            ListaAutoresActual = servicioAutores.GetAll();
        }

        private void AnyadirAutorCommandFun()
        {
            AutorActual = new Autor();
            WeakReferenceMessenger.Default.Send(new AutorNavValueChangedMessage(true));
        }
    }
}
