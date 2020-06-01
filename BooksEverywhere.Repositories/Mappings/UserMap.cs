using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.IdUser);
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.CreatedAt).Not.Nullable();
            Map(x => x.Enabled).Not.Nullable();
        }
    }
}
