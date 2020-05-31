using NHibernate;
using System;
using System.Threading.Tasks;

namespace BooksEverywhere.Repositories.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void BeginTransaction();
        Task RollBackTransaction();
        Task CommitTransaction();
    }
}
