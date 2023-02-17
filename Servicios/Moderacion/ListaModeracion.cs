using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion
{
    /// <summary>
    /// Representa una lista de palabras para moderar.
    /// </summary>
    class ListaModeracion : ObservableObject
    {
        private ObservableCollection<string> listaPalabras;

        /// <summary>
        /// Obtiene o establece la lista de palabras.
        /// </summary>
        public ObservableCollection<string> ListaPalabras
        {
            get { return listaPalabras; }
            set { SetProperty(ref listaPalabras, value); }
        }

        /// <summary>
        /// Obtiene o establece el identificador de la lista.
        /// </summary>
        private string id;

        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase ListaModeracion.
        /// </summary>
        /// <param name="listaPalabras">La lista de palabras a moderar.</param>
        /// <param name="id">El identificador de la lista.</param>
        public ListaModeracion(ObservableCollection<string> listaPalabras, string id, string nombre)
        {
            Nombre = nombre;
            Id = id;
            ListaPalabras = listaPalabras;
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
