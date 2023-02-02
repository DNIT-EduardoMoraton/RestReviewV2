using System;
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
        public Seccion(SeccionEntity seccion)
        {
            this.Id = seccion.Id;
            this.Nombre = seccion.Nombre;
            this.Descripcion = seccion.Descripcion;
        }
        public Seccion()
        {

        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
