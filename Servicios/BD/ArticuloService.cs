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
    /// <summary>
    /// Clase que maneja la lógica de negocios para la gestión de Articulos en la base de datos.
    /// </summary>
    class ArticuloService
    {
        private DAOArticulos daoArticulos;
        private DAOAutores daoAutores;
        private DAOSecciones daoSecciones;

        /// <summary>
        /// Constructor de la clase ArticuloService. Inicializa los objetos DAO para acceder a las tablas de Articulos, Autores y Secciones.
        /// </summary>
        public ArticuloService()
        {
            daoArticulos = new DAOArticulos();
            daoAutores = new DAOAutores();
            daoSecciones = new DAOSecciones();
        }


        /// <summary>
        /// Retorna todos los Articulos de la base de datos en una ObservableCollection.
        /// </summary>
        /// <returns>ObservableCollection de Articulos.</returns>
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

        /// <summary>
        /// Retorna todos los Articulos publicados de la base de datos en una ObservableCollection.
        /// </summary>
        /// <returns>ObservableCollection de Articulos publicados.</returns>
        public ObservableCollection<Articulo> GetAllPublicados()
        {
            return new ObservableCollection<Articulo>(this.GetAll().Where(m => m.IsPublicado));
        }


        /// <summary>
        /// Retorna todos los Articulos de la base de datos que pertenecen a una sección dada en una ObservableCollection.
        /// </summary>
        /// <param name="seccion">Sección a la que pertenecen los Articulos.</param>
        /// <returns>ObservableCollection de Articulos de la sección dada.</returns>
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


        /// <summary>
        /// Retorna todos los Articulos publicados de la base de datos que pertenecen a una sección dada en una ObservableCollection.
        /// </summary>
        /// <param name="seccion">Sección a la que pertenecen los Articulos.</param>
        /// <returns>ObservableCollection de Articulos publicados de la sección dada.</returns>
        public ObservableCollection<Articulo> GetAllBySeccionPublicados(Seccion seccion)
        {
            ObservableCollection<Articulo> newList = GetAllBySeccion(seccion);
            
            return new ObservableCollection<Articulo>(newList.Where(m => m.IsPublicado));

        }


        /// <summary>
        /// Agrega un nuevo artículo a la base de datos.
        /// </summary>
        /// <param name="articulo">El artículo que se va a agregar.</param>
        /// <returns>true si el artículo se agregó correctamente, de lo contrario, false.</returns>
        public bool add(Articulo articulo)
        {
            articulo.IdAutor = articulo.Autor.Id;
            articulo.IdSeccion = articulo.Seccion.Id;
            articulo.FechaPublicacionDate = DateTime.Now;

            if(daoArticulos.Insert(articulo) > 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Edita un artículo existente en la base de datos.
        /// </summary>
        /// <param name="articulo">El artículo que se va a editar.</param>
        public void Edit(Articulo articulo)
        {
            daoArticulos.EditArticulo(articulo);
        }

        /// <summary>
        /// Elimina un artículo existente de la base de datos.
        /// </summary>
        /// <param name="articulo">El artículo que se va a eliminar.</param>
        public void Delete(Articulo articulo)
        {
            daoArticulos.Delete(articulo);
        }
    }
}
