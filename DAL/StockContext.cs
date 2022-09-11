using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDStock.Models;
using System.Data.Entity;

namespace GDStock.DAL
{
    public class StockContext:DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Entries> Entries { get; set; }
        public DbSet<Exits> Exits { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Stocks> Stocks { get; set; }

    }
}