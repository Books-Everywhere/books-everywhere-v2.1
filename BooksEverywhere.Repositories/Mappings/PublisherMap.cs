using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class PublisherMap : ClassMap<Publisher>
    {
        public PublisherMap()
        {
            Table("publisher");
            Id(x => x.IdPublisher, "id");
            Map(x => x.Name, "name").Not.Nullable();
            Map(x => x.CreatedAt, "created_at").Not.Nullable();
        }
    }
}
