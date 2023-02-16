﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.Moderacion.clases
{
    class APIRootList
    {
        public APIData Data { get; set; }
        public APIPaging Paging { get; set; }
        public override string ToString()
        {
            return Data.Terms.Count().ToString();
        }
    }
}