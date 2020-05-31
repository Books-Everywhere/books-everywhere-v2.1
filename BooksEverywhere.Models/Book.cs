using BooksEverywhere.Models.Enums;
using System;

namespace BooksEverywhere.Models
{
  public class Book
  {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public string Language { get; set; } // pt-br, us
        public DateTime PublicationDate { get; set; }
        public DateTime CreateAt { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public BookGenre BookGenre { get; set; }

        Book()
        {
            CreateAt = DateTime.Now;
        }
    }
}
