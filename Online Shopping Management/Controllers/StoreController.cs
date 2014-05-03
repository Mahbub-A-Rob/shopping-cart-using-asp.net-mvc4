using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_Management.Models;

namespace Online_Shopping_Management.Controllers
{
    public class StoreController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var category = db.Categorys.ToList();
            return View(category);
        }

        public ActionResult Browse(string categories)
        {
            var categoryModel = db.Categorys.Include("Products").Single(c => c.Name == categories);
            return View(categoryModel);
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var catogories = db.Categorys.ToList();
            return PartialView(catogories);
        }

    }
}
