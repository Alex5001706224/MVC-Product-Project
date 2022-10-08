using Microsoft.EntityFrameworkCore;

namespace Assignment_12_1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
          
        }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Manufacture>? Manufactures { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacture>().HasData(
                new Manufacture { MakeId = 1, MakeName = "Benz" },
                new Manufacture { MakeId = 2, MakeName = "Bugatti" },
                new Manufacture { MakeId = 3, MakeName = "Lamborghin" },
                new Manufacture { MakeId = 4, MakeName = "McLaren" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 51, MakeId=1, Manufacture = Make.Benz, PName = "Benz", PDescription = "Benz New Car", ImageName = "Benz.jfif", Price = 153825 },
                new Product { Id = 52, MakeId=2, Manufacture = Make.Bugatti, PName = "Bugatti", PDescription = "Bugatti New Model", ImageName = "bugatti.jfif", Price = 372658 },
                new Product { Id = 53, MakeId=3, Manufacture = Make.Lamborghini, PName = "Lamborghini", PDescription = "Lamborghini, do you want it?", ImageName = "lamborghini.jfif", Price = 435699 },
                new Product { Id = 54, MakeId=4, Manufacture = Make.McLaren, PName = "Mclaren", PDescription = "What about McLaren?", ImageName = "mclaren.jfif", Price = 368999 }
                );
        }
    }
}
