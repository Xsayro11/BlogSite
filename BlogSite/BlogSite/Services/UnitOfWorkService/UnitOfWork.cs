using Autofac;
using BlogSite.DAL;
using BlogSite.Models.EntityModels;
using BlogSite.Services.RepositoryService;
using System;

namespace BlogSite.Services.UnitOfWorkService
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IContext _context;
        private Lazy<IRepository<User>> _userRepository;
        bool _disposed = false;

        public UnitOfWork(ILifetimeScope scope)
        {
            this._context = scope.Resolve<IContext>();
            this._userRepository = new Lazy<IRepository<User>>(() => scope.Resolve<IRepository<User>>(new NamedParameter("context", _context)));
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return this._userRepository.Value;
            }
        }

        public void SaveChanges()
        {
            if (_context != null)
                this._context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;

            if (disposing)
            {
                if (_context != null)
                {
                    this._context.Dispose();
                }
            }

            this._disposed = true;
        }
    }
}