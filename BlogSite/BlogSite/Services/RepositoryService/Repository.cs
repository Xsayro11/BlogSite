using BlogSite.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogSite.Services.RepositoryService
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IContext _context;
        private IDbSet<TEntity> _dbSet;

        public Repository(IContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }

        public IDbSet<TEntity> DbSet
        {
            get
            {
                return this._dbSet;
            }
        }

        public List<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public TEntity GetById(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }
    }
}