using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectcv.Models.Entity;
using projectcv.Models.Sinif;
using PagedList;
using PagedList.Mvc;

namespace projectcv.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(int sayfa = 1)
        {
            // Class1 cs = new Class1();
            var degerler = db.TBLINTEREST.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(TBLINTEREST p)
        {
            db.TBLINTEREST.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var hobi = db.TBLINTEREST.Find(id);
            db.TBLINTEREST.Remove(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HobiGetir(int id)
        {
            var hobiler = db.TBLINTEREST.Find(id);
            return View("HobiGetir", hobiler);
        }
        public ActionResult Guncelle(TBLINTEREST p)
        {
            var degerler = db.TBLINTEREST.Find(p.ID);
            degerler.INTEREST = p.INTEREST;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}