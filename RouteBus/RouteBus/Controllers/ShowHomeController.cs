using RouteBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteBus.Controllers
{
    public class ShowHomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Accounts()
        {
            using (Entities dc= new Entities())
            {
                var uAccounts = dc.uAccounts.OrderBy(a => a.Ime).ToList();
                return Json(new { data = uAccounts }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (Entities dc = new Entities())
            {
                var v = dc.uAccounts.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(uAccount acc)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (Entities dc = new Entities())
                {
                    if (acc.Id > 0)
                    {
                        //Edit
                        var v = dc.uAccounts.Where(a => a.Id == acc.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.Ime = acc.Ime;
                            v.Prezime = acc.Prezime;
                            v.userName = acc.userName;
                            v.pass = acc.pass;
                            v.role = acc.role;
                        }
                    }
                    else
                    {
                        //Save
                        dc.uAccounts.Add(acc);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (Entities dc = new Entities())
            {
                var v = dc.uAccounts.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteAccout(int id)
        {
            bool status = false;
            using (Entities dc = new Entities())
            {
                var v = dc.uAccounts.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.uAccounts.Remove(v);
                    dc.SaveChanges();
                    status = true;

                }
            }

            return new JsonResult { Data = new { status = status } };

        }
   

	}
}