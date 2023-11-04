using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryPlatform.Data.Core
{
    public class FoodDeliveryDbContext : IdentityDbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                 .HasOne(o => o.User)
                 .WithMany(u => u.Order)
                 .HasForeignKey(o => o.UserID)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Order)
                .HasForeignKey(o => o.RestaurantID)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<DeliveryPersonnel> DeliveryPersonnels { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
    }
}
