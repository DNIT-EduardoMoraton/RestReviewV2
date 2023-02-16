using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestReviewV2.Servicios.Moderacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestReviewV2.Vistas.UserControls.Moderacion
{
    class ModeracionUserControlVM : ObservableRecipient
    {
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


        private string palabraActual;

        public string PalabraActual
        {
            get { return palabraActual; }
            set { SetProperty(ref palabraActual, value);  }
        }

        // Commands

        public RelayCommand CreateListCommand { get; set; }
        public RelayCommand CreatePalabraCommand { get; set; }

        // Servicios

        private ModeratorService servicioModeracion;

        public ModeracionUserControlVM()
        {
            servicioModeracion = new ModeratorService();
            InicioPorDefectoAsync();
            ManejadorCommands();
        }

        private async Task InicioPorDefectoAsync()
        {
            ListaModeracionActual = new ListaModeracion(new ObservableCollection<string>(), "");

            Task t = Task.Run(async () =>
            {
                ListasModeracion = servicioModeracion.GetAllLists().Result;

                foreach (var item in ListasModeracion)
                {
                    item.ListaPalabras = await servicioModeracion.GetTerms(item.Id);
                }

            });

        }

        private void ManejadorCommands()
        {
            CreateListCommand = new RelayCommand(CreateListFun);
            CreatePalabraCommand = new RelayCommand(CreatePalabraFun);
        }

        private void CreateListFun()
        {

        }

        private void CreatePalabraFun()
        {

        }
    }
}
