using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{

    /// <summary>
    /// Representa la raíz de una respuesta de API que contiene una lista de términos.
    /// </summary>
    class APIRootList
    {

        /// <summary>
        /// Obtiene o establece los datos de la respuesta de la API, que incluyen la lista de términos.
        /// </summary>
        public APIData Data { get; set; }

        /// <summary>
        /// Obtiene o establece la información de paginación de la respuesta de la API.
        /// </summary>
        public APIPaging Paging { get; set; }

        /// <summary>
        /// Devuelve una representación en forma de cadena de la cantidad de términos contenidos en los datos de la respuesta de la API.
        /// </summary>
        public override string ToString()
        {
            return Data.Terms.Count().ToString();
        }
    }
}
