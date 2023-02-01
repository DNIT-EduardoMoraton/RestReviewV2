
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Modelo
{
    public class AutorEntity : ObservableObject
    {
        // Getters y Setters

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



        // Constructor
        public AutorEntity(int id, string nombre, string imagen, string nickName, string redsocial)
        {
            this.id = id;
            this.nombre = nombre;
            this.imagen = imagen;
            this.nickName = nickName;
            this.redsocial = redsocial;
        }


    }



}
