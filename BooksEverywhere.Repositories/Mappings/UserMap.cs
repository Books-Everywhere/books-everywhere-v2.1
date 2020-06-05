using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("user");
            Id(x => x.IdUser, "id");
            Map(x => x.UserName, "username").Not.Nullable();
            Map(x => x.Email, "email").Not.Nullable();
            Map(x => x.Name, "name").Nullable();
            Map(x => x.LastName, "lastname").Nullable();
            Map(x => x.Gender, "gender").Nullable();
            Map(x => x.BirthDate, "birthdate").Nullable();
            Map(x => x.CreatedAt, "created_at").Not.Nullable();
            Map(x => x.Enabled, "enabled").Not.Nullable();
        }
    }
}
