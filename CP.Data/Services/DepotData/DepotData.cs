using CP.Data.Models;
using CP.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace CP.Data.Services.DepotData
{
    public class DepotData : IDepotData
    {
        private readonly AppDbContext db;

        public DepotData(AppDbContext db)
        {
            this.db = db;
        }
        

        // GetAll
        public IEnumerable<Depot> GetDepots()
        {
            return db.Depots.OrderBy(x => x.DepotId);
        }

        // GetID
        public Depot GetDepot(int id)
        {
            return db.Depots.FirstOrDefault(x => x.DepotId == id);
        }

        // Add
        public void AddDepot(Depot depot)
        {
            db.Depots.Add(depot);
            db.SaveChanges();
        }
        
        // Update
        public void UpdateDepot(Depot depot)
        {
            var entry = db.Entry(depot);
            entry.State = EntityState.Modified;
            db.SaveChanges();

            //var existing = GetDepot(depot.DepotId);
            //if (existing != null)
            //{
            //    existing.DepotName = depot.DepotName;
            //    existing.DepotCountryCode = depot.DepotCountryCode;
            //}
        }

        // Delete
        public void DeleteDepot(int id)
        {
            var depot = db.Depots.Find(id);
            db.Depots.Remove(depot);
            db.SaveChanges();
        }

        public Dictionary<string, List<DrugUnit>> DepotInventory()
        {
            var depotInventory = db.DrugUnits
                    .GroupBy(x => x.DrugUnitDepot)
                    .ToDictionary(x => x.Key, x => x.ToList());

            return depotInventory;
        }

        public Dictionary<string, List<DepotWeightViewModel>> DepotWeight()
        {
            const decimal CONVERSION_KG_TO_LBS = 2.2m;
            var depotQuery = db.DrugUnits.Join(db.DrugTypes,
                                 unit => unit.AssignedTypeName,
                                 type => type.DrugTypeName,
                                 (unit, type) => new DepotWeightViewModel
                                 {
                                     Depot = unit.DrugUnitDepot,
                                     UnitType = unit.AssignedTypeName,
                                     UnitName = unit.DrugUnitName,
                                     Weight = type.DrugTypeWeight * CONVERSION_KG_TO_LBS
                                 });

            var depotDrugWeight = depotQuery.GroupBy(x => x.Depot)
                                  .ToDictionary(x => x.Key, x => x.ToList());

            return depotDrugWeight;
            
        }
    }
}
