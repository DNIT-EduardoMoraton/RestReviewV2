namespace RestReviewV2.Servicios.Moderacion.clases
{
    /// <summary>
    /// Representa información de paginación de una respuesta de la API.
    /// </summary>
    public class APIPaging
    {
        /// <summary>
        /// Obtiene o establece el número total de elementos.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Obtiene o establece el límite de elementos por página.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Obtiene o establece el índice de desplazamiento de la página actual.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Obtiene o establece el número de elementos devueltos en la página actual.
        /// </summary>
        public int Returned { get; set; }
    }
}