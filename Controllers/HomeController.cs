using EmlakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EmlakProject.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;

            var ilan = db.Ilans.Include(m => m.Mahalle).Include(e => e.Tip);
            return View(ilan.ToList());
        }

        public ActionResult Details(int id)
        {
            var ilan = db.Ilans.Where(i => i.IlanId == id).Include(m => m.Mahalle).Include(e => e.Tip).FirstOrDefault();
            var imgs = db.Images.Where(i => i.IlanId == id).ToList();
            ViewBag.imgs = imgs;

            return View(ilan);
        }

        public ActionResult MenuFilter(int id)
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;

            var filter = db.Ilans.Where(i => i.TipId == id).Include(m => m.Mahalle).Include(e => e.Tip).ToList();

            return View(filter);
        }

        public PartialViewResult PartialFilter()
        {
            ViewBag.citylist = new SelectList(GetCity(), "CityId", "CityName");
            ViewBag.durumlist = new SelectList(GetDurum(), "DurumId", "DurumName");
            return PartialView();
        }
        public ActionResult Filter(int min, int max, int cityid, int mahalleid, int semtid, int durumid, int tipid)
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;

            var filter = db.Ilans.Where(i => i.Price >= min && i.Price <= max
                && i.DurumId == durumid
                && i.SemtId == semtid
                && i.MahalleId == mahalleid
                && i.CityId == cityid
                && i.TipId == tipid).Include(m => m.Mahalle).Include(e => e.Tip).ToList();


            return View(filter);
        }
        public List<City> GetCity()
        {
            List<City> cities = db.Cities.ToList(); // Bütün şehirleri getirdim.
            return cities;
        }
        public ActionResult GetSemt(int CityId)
        {
            List<Semt> semtlist = db.Semts.Where(x => x.CityId == CityId).ToList(); //where ile sorgu yaparak şehrin semtlerini listeledimm.
            ViewBag.semtlistesi = new SelectList(semtlist, "SemtId", "SemtName");
            return PartialView("SemtPartial");
        }

        public ActionResult GetMahalle(int SemtId)
        {
            List<Mahalle> mahallelist = db.Mahalles.Where(x => x.SemtId == SemtId).ToList();
            ViewBag.mahallelistesi = new SelectList(mahallelist, "MahalleId", "MahalleName");
            return PartialView("MahallePartial");
        }

        public List<Durum> GetDurum()
        {
            List<Durum> durumlar = db.Durums.ToList(); //Durumları getirdim.
            return durumlar;
        }

        public ActionResult GetTip(int DurumId)
        {
            List<Tip> tiplist = db.Tips.Where(x => x.DurumId == DurumId).ToList();
            ViewBag.tiplistesi = new SelectList(tiplist, "TipId", "TipName");
            return PartialView("TipPartial");
        }

        public ActionResult Search(string q)
        {
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;

            var search = db.Ilans.Include(m => m.Mahalle).Include(e => e.Tip);
            if (!string.IsNullOrEmpty(q)) // q boş değilse yani değer geldiyse
            {
                search = search.Where(i => i.IlanDescription.Contains(q) || i.Mahalle.MahalleName.Contains(q) || i.Tip.TipName.Contains(q));
            }

            return View(search.ToList());
        }
    }
}