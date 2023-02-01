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
            List<ArticuloEntity> list = daoArticulos.getAll();
            ObservableCollection<Articulo> newList;
            newList = new ObservableCollection<Articulo>(list.Select(m =>
            {
                (m as Articulo).Autor = (Autor)daoAutores.geById(m.IdAutor);
                (m as Articulo).Seccion = (Seccion)daoSecciones.GetById(m.IdSeccion);
                return (Articulo)m;
            }));
            

            return newList;
        }
    }
}
