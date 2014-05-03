using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_Management.Models;
using Online_Shopping_Management.ViewModels;

namespace Online_Shopping_Management.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Products.Single(product => product.ProductId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProduct);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string productName = db.Carts.Single(item => item.RecordId == id).Product.ProductName;
            int itemCount = cart.RemoveFromCart(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + "has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}
