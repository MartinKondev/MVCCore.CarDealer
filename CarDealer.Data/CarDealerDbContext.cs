namespace CarDealer.Data
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<PartCar> PartCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasOne<Customer>()
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId)
                .HasForeignKey(x => x.CarId);

            modelBuilder
                .Entity<Sale>()
                .HasOne<Car>()
                .WithMany(x => x.Sales);


            modelBuilder
                .Entity<Car>()
                .HasMany<PartCar>()
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarId);

            modelBuilder
                .Entity<Part>()
                .HasMany<PartCar>()
                .WithOne(x => x.Part)
                .HasForeignKey(x => x.PartId);
           

            modelBuilder
                .Entity<Supplier>()
                .HasMany<Part>()
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierId);
        }
    }
}
