using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Management.Models
{
    public class Image
    {
        [Key]
        public int ImageId { set; get; }
        public int? CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public int? SubCategoryId { set; get; }
        public int? ModelId { set; get; }
        public virtual Model Model { set; get; }
        public Image UploadImage { set; get; }
        public string ImageName { set; get; }
    }
}