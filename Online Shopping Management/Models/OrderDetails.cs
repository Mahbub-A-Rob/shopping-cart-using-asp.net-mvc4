using System.ComponentModel.DataAnnotations;

namespace Online_Shopping_Management.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}