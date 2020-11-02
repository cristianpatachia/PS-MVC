using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<DrugUnit> DrugUnits { get; set; }
        public DbSet<Site> Sites { get; set; }

        public AppDbContext() : base("InternshipDbContext")
        {

        }
    }
}

//<add name = "InternshipDbContext"
//         connectionString="Data Source = localhost; 
//                           Initial Catalog = internship.cristian.patachia;
//Integrated Security = True;
//MultipleActiveResultSets = True;"
//         providerName="System.Data.SqlClient" />
//    Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False