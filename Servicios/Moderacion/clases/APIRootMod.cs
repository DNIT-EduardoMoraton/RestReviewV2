using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{
    class APIRootMod
    {
        public string OriginalText { get; set; }
        public string NormalizedText { get; set; }
        public string AutoCorrectedText { get; set; }
        public object Misrepresentation { get; set; }
        public string Language { get; set; }
        public List<APITermino> Terms { get; set; }
        public APIStatus Status { get; set; }
        public string TrackingId { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(OriginalText)}={OriginalText}, {nameof(NormalizedText)}={NormalizedText}, {nameof(AutoCorrectedText)}={AutoCorrectedText}, {nameof(Misrepresentation)}={Misrepresentation}, {nameof(Language)}={Language}, {nameof(Terms)}={Terms}, {nameof(Status)}={Status}, {nameof(TrackingId)}={TrackingId}}}";
        }
    }
}
