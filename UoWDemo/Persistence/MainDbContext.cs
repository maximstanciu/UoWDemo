using Microsoft.EntityFrameworkCore;
using UoWDemo.Entities;

namespace UoWDemo.Persistence
{
    public class MainDbContext : DbContext, IMainDbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var item in ChangeTracker.Entries<IEntity>().AsEnumerable())
            {
                //Auto Timestamp
                item.Entity.CreatedAt = DateTime.Now;
                item.Entity.UpdatedAt = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Address>().ToTable("Addresses");

            //Seed some dummy data
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Jordan", LastName = "Davila", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = 2, FirstName = "Giovanni", LastName = "Krueger", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = 3, FirstName = "Marjorie", LastName = "Nolan", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, Country = "Portuguese", POBox = "1900-349", City = "Lisboa", Street = "Yango Avenida, Quadra 25", Apartment = "3", PersonId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Address { Id = 2, Country = "Portuguese", POBox = "1900-123", City = "Faro", Street = "Braga Rua, Quadra 01", Apartment = "54", PersonId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Address { Id = 3, Country = "Portuguese", POBox = "1900-73", City = "Albufeira", Street = "Moraes Alameda, Casa 2", Apartment = "", PersonId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        }
    }
}
