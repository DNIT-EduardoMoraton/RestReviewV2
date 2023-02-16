using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{
    /// <summary>
    /// Clase que representa una respuesta de la API de términos, modificada.
    /// </summary>
    class APIRootMod
    {
        /// <summary>
        /// El texto original que se proporcionó en la solicitud.
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// El texto normalizado que se devuelve en la respuesta.
        /// </summary>
        public string NormalizedText { get; set; }

        /// <summary>
        /// El texto corregido automáticamente, si se detecta un error ortográfico.
        /// </summary>
        public string AutoCorrectedText { get; set; }

        /// <summary>
        /// Una representación alternativa, si la hay, del término solicitado.
        /// </summary>
        public object Misrepresentation { get; set; }

        /// <summary>
        /// El idioma del término solicitado.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// La lista de términos que coinciden con el término solicitado.
        /// </summary>
        public List<APITermino> Terms { get; set; }

        /// <summary>
        /// El estado de la respuesta de la API.
        /// </summary>
        public APIStatus Status { get; set; }

        /// <summary>
        /// El identificador de seguimiento de la solicitud.
        /// </summary>
        public string TrackingId { get; set; }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            return $"{{{nameof(OriginalText)}={OriginalText}, {nameof(NormalizedText)}={NormalizedText}, {nameof(AutoCorrectedText)}={AutoCorrectedText}, {nameof(Misrepresentation)}={Misrepresentation}, {nameof(Language)}={Language}, {nameof(Terms)}={Terms}, {nameof(Status)}={Status}, {nameof(TrackingId)}={TrackingId}}}";
        }
    }
}
