using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectcv.Models.Entity;
using projectcv.Models.Sinif;
namespace projectcv.Controllers
{
    public class SSController : Controller
    {
        // GET: SS
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLAWARDS select d;
            if (!string.IsNullOrEmpty(p) )
            {
                degerler = degerler.Where(m => m.AWARD.Contains(p));
            }
           // Class1 cs = new Class1();
            //cs.deger6 = db.TBLAWARDS.ToList();
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniSS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSS(TBLAWARDS p)
        {
            db.TBLAWARDS.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var ss = db.TBLAWARDS.Find(id);
            db.TBLAWARDS.Remove(ss);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SSGetir(int id)
        {
            var ss = db.TBLAWARDS.Find(id);
            return View("SSGetir", ss);
        }
        public ActionResult Guncelle(TBLAWARDS p)
        {
            var degerler = db.TBLAWARDS.Find(p.ID);
            degerler.AWARD = p.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}