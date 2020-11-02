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
    }
}
