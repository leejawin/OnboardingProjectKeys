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
    public class ProductsController : Controller
    {
        private KeysOnboardingContext db = new KeysOnboardingContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public JsonResult List()
        {
            var product = db.Products.Select(x => new
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Price = x.Price,

            }).ToList();

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Product product)
        {
            db.Products.Add(product);

            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var product = db.Products.Where(x => x.Id == Id).Select(x => new
            {

                Id = x.Id,
                ProductName = x.ProductName,
                Price = x.Price,

            }).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;

                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RemoveProduct(int Id)
        {
            Product product = db.Products.Find(Id);
            db.Products.Remove(product);
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
