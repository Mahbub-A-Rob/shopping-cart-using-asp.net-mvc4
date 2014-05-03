using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Management.Models
{
    public class Product
    {
        [Key]
        public int ProductId { set; get; }
        public int? CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public int? SubCategoryId { set; get; }
        public virtual SubCategory SubCategory { set; get; }
        public int? ModelId { set; get; }
        public virtual Model Model { set; get; }
        public string ProductName { set; get; }
        public string Number { set; get; }
        public string Color { set; get; }
        public decimal StandardCost { set; get; }
        public decimal ListPrice { set; get; }
        public string Size { set; get; }
        public double Weight { set; get; }
        public DateTime ProductionDate { set; get; }
        public DateTime ExperiedDate { set; get; }
    }
}