using BooksEverywhere.Models;
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
                .Database(MySQLConfiguration.Standard.ConnectionString($"Server=books-everywhere.cdplvfbgl805.us-east-1.rds.amazonaws.com;Port=3306;Database=innodb;user=admin;password=BoOkSEvErYwHeRe576&;Pooling=true;CharSet=utf8;"))
                //.Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
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
