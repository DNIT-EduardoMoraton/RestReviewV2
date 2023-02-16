using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion
{
    class CustomListResponse
    {
        public string Term { get; set; }
        public string ListId { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
    }
}
