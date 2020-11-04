using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Web.Models
{
    public class DepotWeightViewModel
    {
        public string Depot { get; set; }
        public string UnitType { get; set; }
        public string UnitName { get; set; }
        public decimal Weight { get; set; }
    }
}