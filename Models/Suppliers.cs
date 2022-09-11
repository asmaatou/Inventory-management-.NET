using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GDStock.Models
{
    public class Suppliers
    {
        public int ID { get; set; }

        [Display(Name = "Supplier First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Supplier Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}