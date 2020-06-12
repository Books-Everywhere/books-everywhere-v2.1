using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class BookGenreMap : ClassMap<BookGenre>
    {
        public BookGenreMap()
        {
            Table("book_genre");
            References(x => x.Book).Column("id").Nullable();
            References(x => x.Genre).Column("id").Nullable();
        }
    }
}
