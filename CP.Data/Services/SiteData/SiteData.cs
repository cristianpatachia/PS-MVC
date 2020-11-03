using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CP.Data.Services.SiteData
{
    public class SiteData : ISiteData
    {
        private readonly AppDbContext db;
                
        public SiteData(AppDbContext db)
        {
            this.db = db;
        }

        // GetAll
        public IEnumerable<Site> GetSites()
        {
            return db.Sites.OrderBy(x => x.SiteId);
        }

        // GetID
        public Site GetSite(int id)
        {
            return db.Sites.FirstOrDefault(x => x.SiteId == id);
        }

        // Add
        public void AddSite(Site site)
        {
            db.Sites.Add(site);
            db.SaveChanges();   
        }
        
        // Update
        public void UpdateSite(Site site)
        {
            var entry = db.Entry(site);
            entry.State = EntityState.Modified;
            db.SaveChanges();

            //var existing = GetSite(site.SiteId);
            //if (existing != null)
            //{
            //    existing.SiteName = site.SiteName;
            //    existing.SiteCountryCode = site.SiteCountryCode;
            //}
        }

        // Delete
        public void DeleteSite(int id)
        {
            var site = db.Sites.Find(id);
            db.Sites.Remove(site);
            db.SaveChanges();
        }

        public IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity)
        {
            var requestedDrugs = db.DrugUnits
                                        .Where(x => x.AssignedTypeName == drugCode)
                                        .Select(x => new DrugUnit
                                        {
                                            AssignedTypeName = x.AssignedTypeName,
                                            DrugUnitId = x.DrugUnitId,
                                            PickNumber = x.PickNumber
                                        }).Take(quantity)
                                        .AsEnumerable();

            return requestedDrugs;
        }

        public void UpdateSiteInventory(int destinationSiteId, string requestedDrugCode, int requestedQuantity)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<DrugUnit>> SiteDetails()
        {
            var groupedSites = db.DrugUnits
                    .GroupBy(x => x.DestinationSite)
                    .ToDictionary(x => x.Key, x => x.ToList());

            return groupedSites;
        }
    }
}
