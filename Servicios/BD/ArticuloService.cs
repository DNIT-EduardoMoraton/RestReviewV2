using GestorRestReview.BD.DAOs;
using GestorRestReview.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.BD
{
    class ArticuloService
    {
        DAOArticulos daoArticulos;
        DAOAutores daoAutores;
        DAOSecciones daoSecciones;
        public ArticuloService()
        {
            daoArticulos = new DAOArticulos();
            daoAutores = new DAOAutores();
            daoSecciones = new DAOSecciones();
        }

        public ObservableCollection<Articulo> getAll()
        {
            /*List<ArticuloEntity> list = daoArticulos.getAll();
            ObservableCollection<Articulo> newList;
            newList = new ObservableCollection<Articulo>(list.Select(m =>
            {
                (m as Articulo).Autor = (Autor)daoAutores.geById(m.IdAutor);
                (m as Articulo).Seccion = (Seccion)daoSecciones.GetById(m.IdSeccion);
                return (Articulo)m;
            }));
            
            */
            ObservableCollection<Articulo> newList;
            newList = new ObservableCollection<Articulo>();
            newList.Add(new Articulo(1, 2, 3, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Las aventuras",
                "https://preview.redd.it/n2vsoettqi291.png?width=640&crop=smart&auto=webp&s=78edff3227820b98500ddefaba98ed521ac20caa", 111111111l));
            newList.Add(new Articulo(1, 2, 3, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Las aventuras",
    "https://preview.redd.it/n2vsoettqi291.png?width=640&crop=smart&auto=webp&s=78edff3227820b98500ddefaba98ed521ac20caa", 111111111l));
            newList.Add(new Articulo(1, 3, 3, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Las aventuras",
    "https://preview.redd.it/n2vsoettqi291.png?width=640&crop=smart&auto=webp&s=78edff3227820b98500ddefaba98ed521ac20caa", 111111111l));
            newList.Add(new Articulo(1, 3, 3, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Las aventuras",
    "https://preview.redd.it/n2vsoettqi291.png?width=640&crop=smart&auto=webp&s=78edff3227820b98500ddefaba98ed521ac20caa", 111111111l));
            return newList;

        }

        public ObservableCollection<Articulo> GetAllBySeccion(Seccion seccion)
        {
            List<ArticuloEntity> list = daoArticulos.GetAllByIdSeccion(seccion);
            ObservableCollection<Articulo> newList;
            newList = new ObservableCollection<Articulo>(list.Select(m =>
            {
                (m as Articulo).Autor = (Autor)daoAutores.geById(m.IdAutor);
                (m as Articulo).Seccion = seccion;
                return (Articulo)m;
            }));

            return newList;

        }

        public bool add(Articulo articulo)
        {
            if(daoArticulos.insert(articulo) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
