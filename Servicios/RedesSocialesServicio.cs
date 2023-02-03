using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios
{
    class RedesSocialesServicio
    {


        public List<string> List { get; set; }


        public RedesSocialesServicio()
        {
            List = new List<string>();
            List.Add("Twitter");
            List.Add("Instagram");
            List.Add("Facebook");
        }




    }
}
