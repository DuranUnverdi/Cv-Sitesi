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
    public class YeteneklerimController : Controller
    {
        // GET: yetenek
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(int sayfa=1)
        {
          //  Class1 cs = new Class1();
            var degerler = db.TBLSKILLS.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLSKILLS p)
        {
            db.TBLSKILLS.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var yetenek = db.TBLSKILLS.Find(id);
            db.TBLSKILLS.Remove(yetenek);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult YetenekGetir(int id)
        {
            var yetenek = db.TBLSKILLS.Find(id);
            return View("YetenekGetir", yetenek);

        }
        public ActionResult Guncelle(TBLSKILLS p)
        {
            var degerler = db.TBLSKILLS.Find(p.ID);
            degerler.SKILL = p.SKILL;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}