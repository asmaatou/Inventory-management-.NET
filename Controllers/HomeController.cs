using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GDStock.Models;
using System.Data.SqlClient;
using GDStock.DAL;
using System.Dynamic;

namespace GDStock.Controllers
{
    public class HomeController : Controller
    {
        private StockContext db = new StockContext();

        public ActionResult Index()
        {
            dynamic dmodel = new ExpandoObject();
            dmodel.Clients = db.Clients.ToList();
            dmodel.Drivers = db.Drivers.ToList();
            dmodel.Suppliers = db.Suppliers.ToList();
            dmodel.Stocks = db.Stocks.ToList();
            dmodel.Entries = db.Entries.ToList();
            dmodel.Exits = db.Exits.ToList();
            return View(dmodel);
        }
    }
}