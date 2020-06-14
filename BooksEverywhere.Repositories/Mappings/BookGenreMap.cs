using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class BookGenreMap : ClassMap<BookGenre>
    {
        public BookGenreMap()
        {
            Table("book_genre");
            //References(x => x.Book).Column("book_id").Nullable();
            //References(x => x.Genre).Column("genre_id").Nullable();
        }
    }
}
