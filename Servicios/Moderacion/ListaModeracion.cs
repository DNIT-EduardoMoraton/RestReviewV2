using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion
{
    class ListaModeracion : ObservableObject
    {
        private ObservableCollection<string> listaPalabras;

        public ObservableCollection<string> ListaPalabras
        {
            get { return listaPalabras; }
            set { SetProperty(ref listaPalabras, value); }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public ListaModeracion()
        {

        }




    }
}
