using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnboardingProjectKeys.Models;

namespace OnboardingProjectKeys.Controllers
{
    public class StoresController : Controller
    {
        private KeysOnboardingContext db = new KeysOnboardingContext();

        // GET: Stores
        public ActionResult Index()
        {
            return View(db.Store.ToList());
        }

        public JsonResult List()
        {
            var stores = db.Store.Select(x => new
            {
                Id = x.Id,
                StoreName = x.StoreName,
                Address = x.Address

            }).ToList();

            return Json(stores, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Store store)
        {
            db.Store.Add(store);

            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var store = db.Store.Where(x => x.Id == ID).Select(x => new
            {

                Id = x.Id,
                StoreName = x.StoreName,
                Address = x.Address,

            }).FirstOrDefault();

            return Json(store, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Store store)
        {
            try
            {
                db.Entry(store).State = EntityState.Modified;

                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }

            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RemoveStore(int ID)
        {
            Store store = db.Store.Find(ID);
            db.Store.Remove(store);
            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
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
