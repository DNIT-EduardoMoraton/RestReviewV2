﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Modelo
{
    class Seccion : SeccionEntity
    {
        public Seccion(int id, string nombre, string descripcion) : base(id, nombre, descripcion)
        {
        }
        public Seccion()
        {

        }
    }
}
