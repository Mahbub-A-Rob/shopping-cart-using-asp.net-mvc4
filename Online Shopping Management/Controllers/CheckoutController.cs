using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_Management.Models;

namespace Online_Shopping_Management.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        private const string PromoCode = "FREE";
        //
        // GET: /Checkout/

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            
                
                    order.UserName = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    db.Orders.Add(order);
                    db.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete", new {id = order.OrderId});
                
            
        }

        public ActionResult Complete(int id)
        {
            bool isValid = db.Orders.Any(o => o.OrderId == id && o.UserName == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
