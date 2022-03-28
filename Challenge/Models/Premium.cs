using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Models
{
    public class Premium
    { 

        public Premium(string carrier, double  premium)
        {
            this.carrier = carrier;
            this.premium = premium;
        }

        public string carrier { get; set; }
        public double premium { get; set; }
    }
}