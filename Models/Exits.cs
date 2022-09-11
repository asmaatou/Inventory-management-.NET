using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDStock.Models
{
    public class Exits
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int? DriversID { get; set; }
        public virtual Drivers Drivers { get; set; }
        public int? ClientsID { get; set; }
        public virtual Clients Clients { get; set; }
        public int? StocksID { get; set; }
        public virtual Stocks Stocks { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
    }
}