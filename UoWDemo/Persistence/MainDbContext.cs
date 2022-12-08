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

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			foreach (var item in ChangeTracker.Entries<AggregateRoot>().AsEnumerable())
			{
				//Auto Timestamp
				item.Entity.CreatedAt = DateTime.Now;
				item.Entity.UpdatedAt = DateTime.Now;
			}
			return await base.SaveChangesAsync(cancellationToken);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("DataSource=MainDb.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Address>().ToTable("Addresses");
        }
	}
}

