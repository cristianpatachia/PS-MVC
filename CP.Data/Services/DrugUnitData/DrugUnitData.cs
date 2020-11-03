using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Data.Models;

namespace CP.Data.Services.DrugUnitData
{
    public class DrugUnitData : IDrugUnitData
    {
        private readonly AppDbContext db;

        public DrugUnitData(AppDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DrugUnit> GetDrugUnits()
        {
            return db.DrugUnits.OrderBy(x => x.DrugUnitId);
        }

        public void AssociateDrugUnits(string depotId, int startPickNumber, int endPickNumber)
        {
            db.DrugUnits
                .Where(x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber)
                .ToList()
                .ForEach(x => x.DrugUnitDepot = depotId);
                                    
        }

        public void Disassociate(int startPickNumber, int endPickNumber)
        {
            db.DrugUnits
                .Where(x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber)
                .ToList()
                .ForEach(x => x.DrugUnitDepot = null);
                
                //  .Select(x => { x.DrugUnitDepot = 0; return x; });
        }

        public Dictionary<string, List<DrugUnit>> GroupedDrugUnits()
        {
            var groupedUnits = db.DrugUnits
                                    .GroupBy(x => x.AssignedTypeName)
                                    .ToDictionary(x => x.Key, x => x.ToList());
            return groupedUnits;
        }
    }
}
