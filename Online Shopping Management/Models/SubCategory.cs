using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Management.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { set; get; }
        public int? CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public string SubCategoryName { set; get; }
        public string Code { set; get; }

    }
}