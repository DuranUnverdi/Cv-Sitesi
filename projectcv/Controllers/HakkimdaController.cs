using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectcv.Models.Entity;
using projectcv.Models.Sinif;

namespace projectcv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TBLABOUT.ToList();
            return View(cs);
        }
        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBLABOUT.Find(id);
            return View("VeriGetir", veriler);
        }
        public ActionResult Guncelle(TBLABOUT p)
        {
            var degerler = db.TBLABOUT.Find(p.ID);
            degerler.NAME = p.NAME;
            degerler.SURNAME = p.SURNAME;
            degerler.PHONE = p.PHONE;
            degerler.MAİL = p.MAİL;
            degerler.ABOUT = p.ABOUT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}