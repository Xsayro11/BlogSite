using BlogSite.Models.EntityModels;
using BlogSite.Services.RepositoryService;
using System;

namespace BlogSite.Services.UnitOfWorkService
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        void SaveChanges();
    }
}