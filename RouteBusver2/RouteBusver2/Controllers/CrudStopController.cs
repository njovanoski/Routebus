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
    public class CrudStopController : Controller
    {
        private RouteBusDataBaseCRUDEntities db = new RouteBusDataBaseCRUDEntities();

        // GET: /CrudStop/
        public ActionResult Index()
        {
            return View(db.Stops.ToList());
        }

        // GET: /CrudStop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = db.Stops.Find(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // GET: /CrudStop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CrudStop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StopID,StopName,Street,Long,LAt,MapsUsable")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Stops.Add(stop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stop);
        }

        // GET: /CrudStop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = db.Stops.Find(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // POST: /CrudStop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StopID,StopName,Street,Long,LAt,MapsUsable")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stop);
        }

        // GET: /CrudStop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = db.Stops.Find(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // POST: /CrudStop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stop stop = db.Stops.Find(id);
            db.Stops.Remove(stop);
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
