using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Services.DrugUnitData 
{
    public interface IDrugUnitData
    {
        IEnumerable<DrugUnit> GetDrugUnits();
        DrugUnit GetDrugUnit(int id);
        void UpdateDrugUnit(DrugUnit drugUnit);
        Dictionary<string, List<DrugUnit>> GroupedDrugUnits();
        void AssociateDrugUnits(string depotId, int startPickNumber, int endPickNumber);
        void Disassociate(int startPickNumber, int endPickNumber);
    }
}
