using DB.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DB
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Characteristic> Characteristic { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }


        public DbSet<Product> Product { get; set; }
    }
}