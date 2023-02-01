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
    class AutoresService
    {
        private DAOAutores dao;

        public AutoresService()
        {
            dao = new DAOAutores();
        }

        public ObservableCollection<Autor> GetAll()
        {
            List<AutorEntity> list = dao.getAll();
            ObservableCollection<Autor> nList = new ObservableCollection<Autor>(list.Select(n =>
            {
                return (Autor)n;
            }));

            return nList;
        }

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
