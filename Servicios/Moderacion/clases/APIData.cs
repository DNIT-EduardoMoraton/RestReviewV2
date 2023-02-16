using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{
    /// <summary>
    /// Representa la información obtenida de la API de moderación de contenido relacionada con una lista de términos.
    /// </summary>
    class APIData
    {
        /// <summary>
        /// Obtiene o establece el idioma de la lista de términos.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Obtiene o establece los términos de la lista.
        /// </summary>
        public List<APITerm> Terms { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la respuesta de la API.
        /// </summary>
        public APIStatus Status { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de seguimiento de la solicitud a la API.
        /// </summary>
        public string TrackingId { get; set; }
    }
}
