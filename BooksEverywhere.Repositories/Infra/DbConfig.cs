using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Reflection;

namespace BooksEverywhere.Repositories.Infra
{
    public class DbConfig : IDbConfig
    {
        private readonly object _lockSession;
        private readonly ISessionFactory _sessionFactory;

        public DbConfig()
        {
            _lockSession = new object();

            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString($"Server=localhost;Port=3306;Database=books_everywhere;user=root;password=12345;Pooling=true;CharSet=utf8;"))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            lock (_lockSession)
            {
                return _sessionFactory.OpenSession();
            }
        }
    }
}
