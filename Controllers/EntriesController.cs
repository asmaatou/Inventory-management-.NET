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
    public class EntriesController : Controller
    {
        private StockContext db = new StockContext();

        // GET: Entries
        public ActionResult Index()
        {
            var entries = db.Entries.Include(e => e.Drivers).Include(e => e.Stocks).Include(e => e.Suppliers);
            return View(entries.ToList());
        }

        // GET: Entries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entries entries = db.Entries.Find(id);
            if (entries == null)
            {
                return HttpNotFound();
            }
            return View(entries);
        }

        // GET: Entries/Create
        public ActionResult Create()
        {
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName");
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName");
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "ID", "FirstName");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,DriversID,SuppliersID,StocksID,Quantity,Price")] Entries entries)
        {
            if (ModelState.IsValid)
            {
                db.Entries.Add(entries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName", entries.DriversID);
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName", entries.StocksID);
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "ID", "FirstName", entries.SuppliersID);
            return View(entries);
        }

        // GET: Entries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entries entries = db.Entries.Find(id);
            if (entries == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName", entries.DriversID);
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName", entries.StocksID);
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "ID", "FirstName", entries.SuppliersID);
            return View(entries);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,DriversID,SuppliersID,StocksID,Quantity,Price")] Entries entries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriversID = new SelectList(db.Drivers, "ID", "FirstName", entries.DriversID);
            ViewBag.StocksID = new SelectList(db.Stocks, "ID", "ProductName", entries.StocksID);
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "ID", "FirstName", entries.SuppliersID);
            return View(entries);
        }

        // GET: Entries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entries entries = db.Entries.Find(id);
            if (entries == null)
            {
                return HttpNotFound();
            }
            return View(entries);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entries entries = db.Entries.Find(id);
            db.Entries.Remove(entries);
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
