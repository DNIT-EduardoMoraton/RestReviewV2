namespace RestReviewV2.Servicios.Moderacion.clases
{
    /// <summary>
    /// Representa el estado de una respuesta de la API.
    /// </summary>
    public class APIStatus
    {
        /// <summary>
        /// El código del estado de la respuesta.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// La descripción del estado de la respuesta.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// La excepción asociada con la respuesta, si existe.
        /// </summary>
        public object Exception { get; set; }
    }

}