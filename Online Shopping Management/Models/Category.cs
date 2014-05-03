using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Management.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }

        public List<Product> Products { get; set; } 
    }
}