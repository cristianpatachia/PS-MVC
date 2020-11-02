using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    public class DrugUnit
    {
        public string DrugUnitId { get; set; }
        public string DrugUnitName { get; set; }
        public int PickNumber { get; set; }
        public string AssignedType { get; set; }
        public int DrugUnitDepot { get; set; }
        public int DestinationSite { get; set; }
    }
}
