using NHibernate;
using System;
using System.Threading.Tasks;

namespace BooksEverywhere.Repositories.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction;
        private ISession _session;

        private readonly object _lockSession;
        private readonly ISessionFactory _sessionFactory;

        public UnitOfWork()
        {
            InitializeSession();
        }

        public ISession Session
        {
            get
            {
                if (!(_session.IsConnected && _session.IsOpen))
                {
                    FinalizeSession();
                    InitializeSession();
                }

                return _session;
            }
        }

        private void InitializeSession()
        {
            lock (_lockSession)
            {
                _sessionFactory.OpenSession();
            }
        }

        private void FinalizeSession()
        {
            _transaction?.Dispose();
            _session?.Close();
            _session?.Dispose();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
            _session.Clear();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                FinalizeSession();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
