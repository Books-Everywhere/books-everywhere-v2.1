using System;

namespace BooksEverywhere.Models
{
  public class Author
    {
        public virtual int IdAuthor { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public Author()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
