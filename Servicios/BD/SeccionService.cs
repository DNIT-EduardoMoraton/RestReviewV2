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
    /// Servicio que permite realizar operaciones con secciones.
    /// </summary>
    class SeccionService 
    {
        private DAOSecciones dao;

        /// <summary>
        /// Crea una nueva instancia de SeccionService y la asocia con un objeto DAOSecciones.
        /// </summary>
        public SeccionService()
        {
            dao = new DAOSecciones();
        }


        /// <summary>
        /// Agrega una nueva sección en la base de datos.
        /// </summary>
        /// <param name="seccion">La sección que se desea agregar.</param>
        /// <returns>Verdadero si la sección se agregó correctamente, falso en caso contrario.</returns>
        public bool Add(Seccion seccion)
        {

            if (dao.Insert(seccion)>0)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Obtiene todas las secciones almacenadas en la base de datos.
        /// </summary>
        /// <returns>Una colección observable de todas las secciones almacenadas.</returns>
        public ObservableCollection<Seccion> GetAll()
        {
            List<SeccionEntity> list = dao.GetAll();
            return new ObservableCollection<Seccion>(list.Select(n => new Seccion(n)));
        }

    }
}
