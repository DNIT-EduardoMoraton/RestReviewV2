using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{

    /// <summary>
    /// Clase que define la estructura de la respuesta del servicio de listas de moderación.
    /// </summary>
    class APIRootListMod
    {

        /// <summary>
        /// Identificador único de la lista de moderación.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la lista de moderación.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción de la lista de moderación.
        /// </summary>
        public string Description { get; set; }
    }
}
