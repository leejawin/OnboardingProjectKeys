using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class ProductSoldViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Product")]
        public long ProductId { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public long CustomerId { get; set; }
        [Required]
        [Display(Name = "Store")]
        public int StoreId { get; set; }
       
        [Display(Name = "Date of Purchase")]
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}", ApplyFormatInEditMode =true)]
        [Required]
        public string DateSold { get; set; }
    }

    public class ProductSoldsController : Controller
    {
        private KeysOnboardingContext db = new KeysOnboardingContext();

        // GET: ProductSolds
        public ActionResult Index()
        {
            var psold = new ProductSold();
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", psold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", psold.ProductId);
            ViewBag.StoreId = new SelectList(db.Store, "Id", "StoreName", psold.StoreId);
            ViewBag.DateSold = new SelectList(db.Store, "Id", "DateSold", psold.Id);
            return View();
        }


        public JsonResult List()
           {
           
        var productsold = db.ProductSold.Include(s => s.Customer).Include(s => s.Product).Include(s => s.Store).Select(x => new
            {
                Id = x.Id,
                ProductId = x.Product.ProductName,
                CustomerId = x.Customer.Name,
                StoreId = x.Store.StoreName,
                DateSold = x.DateSold
            }).ToList();
            
           return Json(productsold, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ProductSold psold)
        {
            db.ProductSold.Add(psold);
            db.SaveChanges();

            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var ProductSold = db.ProductSold.Where(x => x.Id == ID).Select(x => new ProductSoldViewModel
            {
                Id = ID,
                CustomerId = x.CustomerId,
                DateSold = x.DateSold,
                StoreId = x.StoreId,
                ProductId = x.ProductId
            }).FirstOrDefault();
            return Json(ProductSold, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ProductSold psold)
        {
            try
            {
                db.Entry(psold).State = EntityState.Modified;
                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RemoveProduct(long ID)
        {
            ProductSold psold = db.ProductSold.Find(ID);
            db.ProductSold.Remove(psold);
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
