namespace RestReviewV2.Servicios.Moderacion.clases
{
    public class APIPaging
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Returned { get; set; }
    }
}