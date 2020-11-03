using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Models
{
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int SiteId { get; set; }
        [Display(Name = "Name")]
        public string SiteName { get; set; }
        [Display(Name = "Location")]
        public string SiteCountryCode { get; set; }
        // public List<DrugUnit> SiteDrugUnits { get; set; }
    }
}
 