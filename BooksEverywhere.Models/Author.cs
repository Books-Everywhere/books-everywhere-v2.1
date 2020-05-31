using System;

namespace BooksEverywhere.Models
{
  public class Author
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime CreateAt { get; set; }

        Author()
        {
            CreateAt = DateTime.Now;
        }
    }
}
