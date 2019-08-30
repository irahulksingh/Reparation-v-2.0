using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Reparation.Models;

namespace Reparation.DAL
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccounts> userAccounts { get; set; }
        public DbSet<WorkOrders> workOrders { get; set; }

    }
}