using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogSite.Services.RepositoryService
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IDbSet<TEntity> DbSet { get; }
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetById(Guid id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}