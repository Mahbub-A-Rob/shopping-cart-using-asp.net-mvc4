using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_Management.Models;


namespace Online_Shopping_Management.Controllers
{
    public class StoreManagerController : Controller
    {
        private ShoppingDbContext db = new ShoppingDbContext();
        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var product = db.Products.Include(p => p.Category).Include(p => p.SubCategory).Include(p => p.Model);
            return View(product.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId","Name", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", product.ModelId);
            return View(product);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId","Name", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", product.ModelId);
            return View(product);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId","Name", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", product.ModelId);
            return View(product);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
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

