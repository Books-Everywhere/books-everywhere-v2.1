using BooksEverywhere.Models.Enums;
using System;

namespace BooksEverywhere.Models
{
  public class UserBookAction
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public BookAction BookAction { get; set; }
    }
}
