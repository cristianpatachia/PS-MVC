using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    public class DrugUnit
    {
        [Display(Name="ID")]
        public int DrugUnitId { get; set; }
        [Display(Name = "Unit")]
        public string DrugUnitName { get; set; }
        [Display(Name = "Picknumber")]
        public int? PickNumber { get; set; }
        [Display(Name = "Type")]
        public string AssignedTypeName { get; set; }
        [Display(Name = "Depot Origin")]
        public string DrugUnitDepot { get; set; }
        [Display(Name = "Site Destination")]
        public string DestinationSite { get; set; }
    }
}
