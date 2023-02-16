using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios
{

    /// <summary>
    /// Servicio para obtener la lista de redes sociales.
    /// </summary>
    class RedesSocialesServicio
    {

        /// <summary>
        /// Obtiene la lista de redes sociales.
        /// </summary>
        public List<string> List { get; set; }


        /// <summary>
        /// Constructor de la clase RedesSocialesServicio.
        /// Inicializa la lista de redes sociales.
        /// </summary>
        public RedesSocialesServicio()
        {
            List = new List<string>();
            List.Add("Twitter");
            List.Add("Instagram");
            List.Add("Facebook");
        }

    }
}
