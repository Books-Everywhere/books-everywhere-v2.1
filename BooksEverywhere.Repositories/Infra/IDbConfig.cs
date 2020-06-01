using NHibernate;

namespace BooksEverywhere.Repositories.Infra
{
    public interface IDbConfig
    {
        ISession OpenSession();
    }
}
