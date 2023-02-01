
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
        public Autor(int id, string nombre, string imagen, string nickName, string redsocial) : base(id, nombre, imagen, nickName, redsocial)
        {
        }
    }


}
