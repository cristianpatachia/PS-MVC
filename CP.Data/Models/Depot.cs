using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{   
    public class Depot
    {
        [Display(Name = "ID")]
        public int DepotId { get; set; }
        [Display(Name = "Name")]
        public string DepotName { get; set; }
        [Display(Name = "Location")]
        public string DepotCountryCode { get; set; }
        public List<DrugUnit> DepotDrugUnits { get; set; }
    }
}
