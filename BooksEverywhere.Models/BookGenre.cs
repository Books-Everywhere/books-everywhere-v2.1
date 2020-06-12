using BooksEverywhere.Models.Enums;

namespace BooksEverywhere.Models
{
    public class BookGenre
    {
        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
