using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RouteBus.Models;

namespace RouteBus.Controllers
{
    public class NajavaController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Najava
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(uAccount korisnik)
        {
            var kor = db.UAccount.Where(u => u.userName == korisnik.userName && u.pass == korisnik.pass).FirstOrDefault();
                if (kor != null)
                {
                    Session["KorisnikID"] = kor.Id.ToString();
                    Session["KorisnickoIme"] = kor.userName.ToString();
                    return RedirectToAction("Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Корисничкото име или лозинка се неточни");
                }
            
            return View();
        }

        public ActionResult Admin()
        {
            if (Session["KorisnikID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Najava");
            }
        }

        public ActionResult DodajPostojka()
        {
            return View();
        }

        public ActionResult VidiPostojka()
        {
            return View();
        }


        //DA PROVERIME ZA SHO BESHE OVAJ METOD POKASNO ****
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
