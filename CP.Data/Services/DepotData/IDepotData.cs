using CP.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Services.DepotData
{
    public interface IDepotData
    {
        IEnumerable<Depot> GetDepots();
        Depot GetDepot(int id);
        void AddDepot(Depot depot);
        void UpdateDepot(Depot depot);
        void DeleteDepot(int id);
    }
}
