
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Modelo
{
    class Autor : ObservableObject
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string imagen;
        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }
        private string nickName;
        public string NickName
        {
            get { return nickName; }
            set { SetProperty(ref nickName, value); }
        }
        private string redsocial;
        public string Redsocial
        {
            get { return redsocial; }
            set { SetProperty(ref redsocial, value); }
        }
    }
}
