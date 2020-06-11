using System;

namespace BooksEverywhere.Models
{
  public class Author
    {
        public virtual int IdAuthor { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime CreateAt { get; set; }

        public Author()
        {
            CreateAt = DateTime.Now;
        }
    }
}
