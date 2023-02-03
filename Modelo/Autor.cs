
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Modelo
{
    class Autor : AutorEntity
    {
        public Autor()
        {
        }

        public Autor(int id, string nombre, string imagen, string nickName, string redsocial) : base(id, nombre, imagen, nickName, redsocial)
        {
        }

        public Autor(AutorEntity autorEntity) : base(autorEntity.Id, autorEntity.Nombre, autorEntity.Imagen, autorEntity.NickName, autorEntity.Redsocial)
        {
        }


        public override string ToString()
        {
            return this.Nombre; 
        }
    }


}
