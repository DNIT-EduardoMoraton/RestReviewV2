using GestorRestReview.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.BD
{
    class ArticuloService
    {
        public ArticuloService()
        {

        }

        public List<Articulo> getAll()
        {
            List<Articulo> list = new List<Articulo>();
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));
            list.Add(new Articulo(1, 4, 2, "hahahaha", "siiii", "url", new DateTime().Date));

            return list;
        }
    }
}
