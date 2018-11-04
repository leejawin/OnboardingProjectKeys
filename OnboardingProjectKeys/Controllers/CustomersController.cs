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
    public class CustomersController : Controller
    {
        private KeysOnboardingContext db = new KeysOnboardingContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

       

        public JsonResult List()
        {
            var customers = db.Customer.Select(x => new
            {
                Id = x.Id,

                Name = x.Name,
                Address = x.Address
               
            }).ToList();

            return Json(customers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Customer cus)
        {
            db.Customer.Add(cus);

            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var customer = db.Customer.Where(x => x.Id == Id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).FirstOrDefault();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Customer cus)
        {
            try
            {
                db.Entry(cus).State = EntityState.Modified;

                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();

                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult RemoveCustomer(int ID)
        {
            Customer customer = db.Customer.Find(ID);
            db.Customer.Remove(customer);
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

