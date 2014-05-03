using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_Management.Models;

namespace Online_Shopping_Management.Controllers
{
    public class ProductController : Controller
    {
        private ShoppingDbContext db = new ShoppingDbContext();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.SubCategory).Include(p => p.Model);
            return View(products.ToList());
        }

        public ActionResult CategoryList()
        {
            var categories = db.Categorys.ToList();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(
                        new SelectList(
                            categories,
                            "CategoryId",
                            "Name"
                            ), JsonRequestBehavior.AllowGet
                    );
            }

            return View(categories);
        }

        public ActionResult SubCategoryList(int CategoryId)
        {
            var subcategories = from sc in db.SubCategories
                                where sc.CategoryId == CategoryId
                                select sc;

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(
                    new SelectList(
                        subcategories,
                        "SubCategoryId",
                        "SubCategoryName"
                        ), JsonRequestBehavior.AllowGet
                    );
            }
            return View(subcategories);
        }

        public ActionResult ModelList(int SubCategoryId)
        {
                  var models = from m in db.Models
                               where m.SubCategoryId == SubCategoryId
                               select m;

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(
                    new SelectList(
                         models,
                        "ModelId",
                        "ModelName"
                        ), JsonRequestBehavior.AllowGet
                    );
            }
            return View(models);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", product.ModelId);
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", product.ModelId);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", product.ModelId);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}