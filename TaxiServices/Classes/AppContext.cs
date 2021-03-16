using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaxiServices.Classes;

namespace TaxiServices
{
    public class AppContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public AppContext() : base("DefaultConnection") { }
    }
}
