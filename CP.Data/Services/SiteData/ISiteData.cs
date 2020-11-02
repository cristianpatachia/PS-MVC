using CP.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Services.SiteData
{
    public interface ISiteData
    {
        IEnumerable<Site> GetSites();
        Site GetSite(int id);
        void AddSite(Site site);
        void UpdateSite(Site site);
        void DeleteSite(int id);
    }
}
