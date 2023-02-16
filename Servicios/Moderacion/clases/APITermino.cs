using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{
    /// <summary>
    /// Representa un término en la API.
    /// </summary>
    class APITermino
    {
        /// <summary>
        /// Obtiene o establece el índice del término.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Obtiene o establece el índice original del término.
        /// </summary>
        public int OriginalIndex { get; set; }

        /// <summary>
        /// Obtiene o establece el ID de la lista del término.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Obtiene o establece el término.
        /// </summary>
        public string Term { get; set; }
    }


}
