using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_Shopping_Management.Models
{
    public class ShoppingDbContext : DbContext
    {
        public DbSet<Category> Categorys { set; get; }
        public DbSet<SubCategory> SubCategories { set; get; }
        public DbSet<Model> Models { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Image> Images { set; get; } 
    }
}