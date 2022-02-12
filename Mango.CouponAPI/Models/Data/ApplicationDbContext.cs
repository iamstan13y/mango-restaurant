using Microsoft.EntityFrameworkCore;

namespace Mango.CouponAPI.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = 1,
                    CouponCode = "JUL13",
                    DiscountAmount = 2.72
                });

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = 2,
                    CouponCode = "STAN13Y",
                    DiscountAmount = 2.27
                });
        }
    }
}