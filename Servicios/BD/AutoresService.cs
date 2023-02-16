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
    /// Servicio para gestionar autores de artículos.
    /// </summary>
    class AutoresService
    {
        private DAOAutores dao;

        /// <summary>
        /// Inicializa una nueva instancia del servicio <see cref="AutoresService"/>.
        /// </summary>
        public AutoresService()
        {
            dao = new DAOAutores();
        }


        /// <summary>
        /// Obtiene una lista de todos los autores existentes en la base de datos.
        /// </summary>
        /// <returns>Una colección observable de objetos <see cref="Autor"/>.</returns>
        public ObservableCollection<Autor> GetAll()
        {
            List<AutorEntity> list = dao.getAll();
            ObservableCollection<Autor> nList = new ObservableCollection<Autor>(list.Select(n =>
            {
                return (Autor)n;
            }));

            return nList;
        }


        /// <summary>
        /// Agrega un autor a la base de datos.
        /// </summary>
        /// <param name="autor">El autor a agregar.</param>
        /// <returns><c>true</c> si se agregó el autor con éxito, <c>false</c> en caso contrario.</returns>
        public bool add(Autor autor)
        {
            if(dao.insert(autor)>0)
            {
                return true;
            }

            return false;
        }

    }
}
