using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UoWDemo.Persistence
{
    public interface IMainDbContext : IDisposable
	{
		EntityEntry Entry(object entity);
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
