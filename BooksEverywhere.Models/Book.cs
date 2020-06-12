using BooksEverywhere.Models.Enums;
using System;

namespace BooksEverywhere.Models
{
    public class Book
    {
        public virtual int IdBook { get; set; }
        public virtual string Title { get; set; }
        public virtual string ISBN { get; set; }
        public virtual string Edition { get; set; }
        public virtual string Language { get; set; } // pt-br, us etc
        public virtual DateTime PublicationDate { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual string Cover { get; set; }
        public virtual string Synopsis { get; set; }
        public virtual int Pages { get; set; }
               
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }

        public Book()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
