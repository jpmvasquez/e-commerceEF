using E_Commerce_Project.Models.Products;
using E_Commerce_Project.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_Commerce_Project.Data
{
    //public class AppDbContext: DbContext
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitializeDB.seed(modelBuilder);
            //InitializeDB.SeedUsersAndRolesAsync().Wait();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Techno> Techno { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}
