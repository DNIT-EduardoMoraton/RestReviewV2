using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{
    class APIData
    {
        public string Language { get; set; }
        public List<APITerm> Terms { get; set; }
        public APIStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}
