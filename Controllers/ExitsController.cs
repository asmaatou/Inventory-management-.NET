using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDStock.DAL;
using GDStock.Models;

namespace GDStock.Controllers
{
    public class ExitsController : Controller
    {
        private StockContext db = new StockContext();

        // GET: Exits
        public ActionResult Index()
        {
            var exits = db.Exits.Include(e => e.Clients).Include(e => e.Drivers).Include(e => e.Stocks);
            return View(exits.ToList());
        }

        // GET: Exits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exits exits = db.Exits.Find(id);
            if (exits == null)
            {
                return HttpNotFound();
            }
            return View(exits);
        }

        // GET: Exits/Create
        public ActionResult Create()
        {
            ViewBag.ClientsID = new SelectList(db.Clients, "ID", "FirstName");
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName");
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName");
            return View();
        }

        // POST: Exits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,DriversID,ClientsID,StocksID,Quantity,Price")] Exits exits)
        {
            if (ModelState.IsValid)
            {
                db.Exits.Add(exits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientsID = new SelectList(db.Clients, "ID", "FirstName", exits.ClientsID);
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName", exits.DriversID);
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName", exits.StocksID);
            return View(exits);
        }

        // GET: Exits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exits exits = db.Exits.Find(id);
            if (exits == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientsID = new SelectList(db.Clients, "ID", "FirstName", exits.ClientsID);
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName", exits.DriversID);
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName", exits.StocksID);
            return View(exits);
        }

        // POST: Exits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,DriversID,ClientsID,StocksID,Quantity,Price")] Exits exits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientsID = new SelectList(db.Clients, "ID", "FirstName", exits.ClientsID);
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName", exits.DriversID);
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName", exits.StocksID);
            return View(exits);
        }

        // GET: Exits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exits exits = db.Exits.Find(id);
            if (exits == null)
            {
                return HttpNotFound();
            }
            return View(exits);
        }

        // POST: Exits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exits exits = db.Exits.Find(id);
            db.Exits.Remove(exits);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
