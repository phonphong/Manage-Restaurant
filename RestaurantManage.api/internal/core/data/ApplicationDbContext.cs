using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Microsoft.EntityFrameworkCore;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.data.repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Table> Tables{get;set;}
        public DbSet<Reservation> Reservations{get;set;}
        public DbSet<Feedback> Feedbacks{get;set;}
        public DbSet<Customer> Customers{get;set;}

    }
}
