using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestReviewV2.Servicios.Moderacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private string textoNuevaLista;

        public string TextoNuevaLista
        {
            get { return textoNuevaLista; }
            set { SetProperty(ref textoNuevaLista, value); }
        }
        

        private string textoPalabraNueva;
        public string TextoPalabraNueva
        {
            get { return textoPalabraNueva; }
            set { SetProperty(ref textoPalabraNueva, value); }
        }

        // Commands

        public RelayCommand CreateListCommand { get; set; }
        public RelayCommand CreatePalabraCommand { get; set; }
        public RelayCommand DeletePalabraCommand { get; set; }
        public RelayCommand DeleteListCommand { get; set; }
        

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
            ListaModeracionActual = new ListaModeracion(new ObservableCollection<string>(), "", "");
            UpdateLists();
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

            });
        }

        private async Task UpdateCurrList()
        {
            Task t = Task.Run(async () =>
            {
                ListaModeracionActual.ListaPalabras = await servicioModeracion.GetTerms(ListaModeracionActual.Id);

            });
        }

        private void ManejadorCommands()
        {
            CreateListCommand = new RelayCommand(CreateListFun);
            CreatePalabraCommand = new RelayCommand(CreatePalabraFun);
            DeletePalabraCommand = new RelayCommand(DeletePalabraFun);
            DeleteListCommand = new RelayCommand(DeleteListFun);
        }

        private async void DeleteListFun()
        {
            if (ListaModeracionActual==null)
            {
                return;
            }
            Task t = Task.Run(async () =>
            {
                if(servicioModeracion.DeleteList(ListaModeracionActual.Id).Result)
                {
                    await UpdateLists();
                }
                
            });
        }
        private async void CreateListFun()
        {
            if (ListasModeracion.Count >= 5)
            {
                return;
            } else
            {
                Task.Run(async () =>
                {
                    if (servicioModeracion.CreateNewList(TextoNuevaLista).Result)
                    {
                        await UpdateLists();
                    }

                });
                
            }

            
        }

        private async void CreatePalabraFun()
        {
            Task t = Task.Run(async () => { 

                if (TextoPalabraNueva != null && TextoPalabraNueva != "")
                {
                    Debug.WriteLine("añadiendo" + TextoPalabraNueva);
                    if (servicioModeracion.AddTerm(ListaModeracionActual.Id, TextoPalabraNueva).Result)
                    {
                        await UpdateCurrList();
                    }
                }
            });
        }

        private void DeletePalabraFun()
        {
            Task t = Task.Run(async () => {
                if (PalabraActual != null)
                {
                    if (servicioModeracion.DeleteTerm(ListaModeracionActual.Id, PalabraActual).Result)
                    {
                        await UpdateCurrList();
                    }
                }
            });
        }
    }
}
