using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RouteBusver2;

namespace RouteBusver2.Controllers
{
    public class CrudBusController : Controller
    {
        private RouteBusDataBaseCRUDEntities db = new RouteBusDataBaseCRUDEntities();

        // GET: /CrudBus/
        public ActionResult Index()
        {
            return View(db.Trasports.ToList());
        }

        // GET: /CrudBus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trasport trasport = db.Trasports.Find(id);
            if (trasport == null)
            {
                return HttpNotFound();
            }
            return View(trasport);
        }

        // GET: /CrudBus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CrudBus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BusID,BusName,Line")] Trasport trasport)
        {
            if (ModelState.IsValid)
            {
                db.Trasports.Add(trasport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trasport);
        }

        // GET: /CrudBus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trasport trasport = db.Trasports.Find(id);
            if (trasport == null)
            {
                return HttpNotFound();
            }
            return View(trasport);
        }

        // POST: /CrudBus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BusID,BusName,Line")] Trasport trasport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trasport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trasport);
        }

        // GET: /CrudBus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trasport trasport = db.Trasports.Find(id);
            if (trasport == null)
            {
                return HttpNotFound();
            }
            return View(trasport);
        }

        // POST: /CrudBus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trasport trasport = db.Trasports.Find(id);
            db.Trasports.Remove(trasport);
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
