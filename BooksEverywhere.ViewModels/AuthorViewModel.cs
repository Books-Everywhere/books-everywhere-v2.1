using System;

namespace BooksEverywhere.ViewModels
{
    public class AuthorViewModel
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
