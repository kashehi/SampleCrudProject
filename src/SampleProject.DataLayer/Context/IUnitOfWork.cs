using Microsoft.EntityFrameworkCore;

namespace SampleProject.DataLayer.Context
{
    public interface IUnitOfWork : IDisposable
    {

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
     }
}
