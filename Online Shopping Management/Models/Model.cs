using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Management.Models
{
    public class Model
    {
        [Key]
        public int ModelId { set; get; }
        public int? CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public int? SubCategoryId { set; get; }
        public virtual SubCategory SubCategory { set; get; }
        public string ModelName { set; get; }
        public string Description { set; get; }
        public string Code { set; get; }

        
    }
}