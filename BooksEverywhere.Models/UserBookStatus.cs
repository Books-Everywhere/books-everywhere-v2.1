using BooksEverywhere.Models.Enums;
using System;

namespace BooksEverywhere.Models
{
  public class UserBookStatus
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public BookStatus BookStatus { get; set; }
    }
}
