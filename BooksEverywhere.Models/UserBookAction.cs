using BooksEverywhere.Models.Enums;
using System;

namespace BooksEverywhere.Models
{
  public class UserBookAction
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual BookAction BookAction { get; set; }
    }
}
