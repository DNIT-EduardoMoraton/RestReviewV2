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
        private DAOArticulos daoArticulos;
        private DAOAutores daoAutores;
        private DAOSecciones daoSecciones;
        public ArticuloService()
        {
            daoArticulos = new DAOArticulos();
            daoAutores = new DAOAutores();
            daoSecciones = new DAOSecciones();
        }

        public ObservableCollection<Articulo> GetAll()
        {
            List<ArticuloEntity> list = daoArticulos.getAll();
            ObservableCollection<Articulo> newList;
            newList = new ObservableCollection<Articulo>(list.Select(m =>
            {
                AutorEntity autorent = daoAutores.geById(m.IdAutor);
                Articulo art = new Articulo(m);

                art.Autor = new Autor(autorent);
                art.Seccion = new Seccion(daoSecciones.GetById(m.IdSeccion));
                return art;
            }));
            
            
            return newList;

        }

        public ObservableCollection<Articulo> GetAllPublicados()
        {
            return new ObservableCollection<Articulo>(this.GetAll().Where(m => m.IsPublicado));
        }

        public ObservableCollection<Articulo> GetAllBySeccion(Seccion seccion)
        {
            List<ArticuloEntity> list = daoArticulos.GetAllByIdSeccion(seccion);
            ObservableCollection<Articulo> newList;
            newList = new ObservableCollection<Articulo>(list.Select(m =>
            {
                AutorEntity autorent = daoAutores.geById(m.IdAutor);
                Articulo art = new Articulo(m);

                art.Autor = new Autor(autorent);
                art.Seccion = seccion;
                return art;
            }));

            return newList;

        }

        public ObservableCollection<Articulo> GetAllBySeccionPublicados(Seccion seccion)
        {
            ObservableCollection<Articulo> newList = GetAllBySeccion(seccion);
            
            return new ObservableCollection<Articulo>(newList.Where(m => m.IsPublicado));

        }

        public bool add(Articulo articulo)
        {
            articulo.IdAutor = articulo.Autor.Id;
            articulo.IdSeccion = articulo.Seccion.Id;
            articulo.FechaPublicacionDate = DateTime.Now;

            if(daoArticulos.insert(articulo) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
