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
    class SeccionService 
    {
        private DAOSecciones dao;
        public SeccionService()
        {
            dao = new DAOSecciones();
        }

        public bool Add(Seccion seccion)
        {

            if (dao.Insert(seccion)>0)
            {
                return true;
            }

            return false;

        }

        public ObservableCollection<Seccion> GetAll()
        {
            List<SeccionEntity> list = dao.GetAll();
            return new ObservableCollection<Seccion>(list.Select(n => new Seccion(n)));
        }

    }
}
