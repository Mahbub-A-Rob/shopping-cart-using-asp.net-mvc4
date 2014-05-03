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
    public class ImageController : Controller
    {
        private ShoppingDbContext db = new ShoppingDbContext();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Category).Include(i => i.Model);
            return View(images.ToList());
        }
        public ActionResult CategoryListForImage()
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

        public ActionResult SubCategoryListForImage(int CategoryId)
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

        public ActionResult ModelListForImage(int SubCategoryId)
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
        // GET: /Image/Details/5

        public ActionResult Details(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // GET: /Image/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name");
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName");
            return View();
        }

        //
        // POST: /Image/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", image.CategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", image.ModelId);
            return View(image);
        }

        //
        // GET: /Image/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", image.CategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", image.ModelId);
            return View(image);
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "Name", image.CategoryId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelName", image.ModelId);
            return View(image);
        }

        //
        // GET: /Image/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // POST: /Image/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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