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
    public class ModelController : Controller
    {
        private ShoppingDbContext db = new ShoppingDbContext();

        //
        // GET: /Model/

        public ActionResult Index()
        {
            var models = db.Models.Include(m => m.Category).Include(m => m.SubCategory);
            return View(models.ToList());
        }

        public ActionResult CategorysList()
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

        public ActionResult SubCategoriesList(int CategoryId)
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

        //
        // GET: /Model/Details/5

        public ActionResult Details(int id = 0)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // GET: /Model/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
            return View();
        }



        //
        // POST: /Model/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model model)
        {
            Category category = db.Categorys.Find(model.CategoryId);
            SubCategory subCategory = db.SubCategories.Find(model.SubCategoryId);
            
            if (ModelState.IsValid)
            {
                db.Models.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", model.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", model.SubCategoryId);
            return View(model);
        }

        //
        // GET: /Model/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", model.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", model.SubCategoryId);
            return View(model);
        }

        //
        // POST: /Model/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", model.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", model.SubCategoryId);
            return View(model);
        }

        //
        // GET: /Model/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // POST: /Model/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
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