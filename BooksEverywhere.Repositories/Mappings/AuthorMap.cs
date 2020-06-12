using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Table("author");
            Id(x => x.IdAuthor, "id");
            Map(x => x.Name, "name").Not.Nullable();
            Map(x => x.LastName, "last_name").Not.Nullable();
            Map(x => x.Name, "name").Nullable();
            Map(x => x.LastName, "lastname").Nullable();
            Map(x => x.Gender, "gender").Nullable();
            Map(x => x.BirthDate, "birthdate").Nullable();
            Map(x => x.CreatedAt, "created_at").Not.Nullable();
        }
    }
}
