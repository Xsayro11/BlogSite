using System;
using System.Data.Entity;

namespace BlogSite.DAL
{
    public interface IContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}