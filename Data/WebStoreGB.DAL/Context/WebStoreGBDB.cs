using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Domain.Entities.Identity;
using WebStoreGB.Domain.Entities.Orders;

namespace WebStoreGB.DAL.Context
{
    public class WebStoreGBDB : IdentityDbContext<User,Role,string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //
        public WebStoreGBDB(DbContextOptions<WebStoreGBDB> options) : base(options)
        {

        }
    }
}
