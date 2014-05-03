using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shopping_Management.Models
{
    [Bind(Exclude = "OrderId")]
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        public List<OrderDetails> OrderDetails { get; set; } 
    }
}