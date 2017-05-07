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
    public class CrudTimeController : Controller
    {
        private RouteBusDataBaseCRUDEntities db = new RouteBusDataBaseCRUDEntities();

        // GET: /CrudTime/
        public ActionResult Index()
        {
            var times = db.Times.Include(t => t.Stop).Include(t => t.Trasport);
            return View(times.ToList());
        }

        // GET: /CrudTime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // GET: /CrudTime/Create
        public ActionResult Create()
        {
            ViewBag.StopID = new SelectList(db.Stops, "StopID", "StopName");
            ViewBag.BusID = new SelectList(db.Trasports, "BusID", "BusName");
            return View();
        }

        // POST: /CrudTime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TimeID,Time1,StopID,BusID")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Times.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StopID = new SelectList(db.Stops, "StopID", "StopName", time.StopID);
            ViewBag.BusID = new SelectList(db.Trasports, "BusID", "BusName", time.BusID);
            return View(time);
        }

        // GET: /CrudTime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            ViewBag.StopID = new SelectList(db.Stops, "StopID", "StopName", time.StopID);
            ViewBag.BusID = new SelectList(db.Trasports, "BusID", "BusName", time.BusID);
            return View(time);
        }

        // POST: /CrudTime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TimeID,Time1,StopID,BusID")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StopID = new SelectList(db.Stops, "StopID", "StopName", time.StopID);
            ViewBag.BusID = new SelectList(db.Trasports, "BusID", "BusName", time.BusID);
            return View(time);
        }

        // GET: /CrudTime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: /CrudTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.Times.Find(id);
            db.Times.Remove(time);
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
