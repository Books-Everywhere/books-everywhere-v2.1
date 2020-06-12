using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("book");
            Id(x => x.IdBook, "id");
            Map(x => x.Title, "title").Not.Nullable();
            Map(x => x.ISBN, "isbn").Not.Nullable();
            Map(x => x.Edition, "edition").Nullable();
            Map(x => x.PublicationDate, "publication_date").Nullable();
            Map(x => x.Language, "language").Nullable();
            Map(x => x.CreatedAt, "created_at").Not.Nullable();
            Map(x => x.Cover, "cover").Nullable();
            Map(x => x.Synopsis, "synopsis").Nullable();
            Map(x => x.Pages, "pages").Not.Nullable();
            References(x => x.Publisher).Column("id").Nullable();
            References(x => x.Author).Column("id").Nullable();
        }
    }
}
