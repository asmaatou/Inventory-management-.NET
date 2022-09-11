using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GDStock.Models
{
    public class Stocks
    {
        public int ID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        
        public string Description { get; set; }
        
        public int? SuppliersID { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        

    }
}