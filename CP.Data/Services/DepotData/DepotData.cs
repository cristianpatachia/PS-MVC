using CP.Data.Models;
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

        
    }
}
