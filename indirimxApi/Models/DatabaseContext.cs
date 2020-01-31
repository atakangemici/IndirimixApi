using indirimxApi.Models;
using Microsoft.EntityFrameworkCore;

namespace indirimxApi
{
    public class indirimxContext : DbContext
    {

        public DbSet<Comments> Comments { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CustomUsers> CustomUsers { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        public indirimxContext(DbContextOptions<indirimxContext> options)
     : base(options)
        {

        }
    }
}