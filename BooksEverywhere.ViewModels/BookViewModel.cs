using BooksEverywhere.ViewModels.Enums;
using System;

namespace BooksEverywhere.ViewModels
{
    public class BookViewModel
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public string Language { get; set; } // pt-br, us etc
        public DateTime PublicationDate { get; set; }
        public DateTime CreateAt { get; set; }

        public AuthorViewModel Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public BookGenreViewModel BookGenre { get; set; }
    }
}
