using BooksEverywhere.Models.Enums;
using System;

namespace BooksEverywhere.Models
{
    public class UserBookStatus
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual DateTime StartedAt { get; set; }
        public virtual DateTime FinishedAt { get; set; }
        public virtual BookStatus BookStatus { get; set; }
    }
}
