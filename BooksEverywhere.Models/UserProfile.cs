using System;

namespace BooksEverywhere.Models
{
  public class UserProfile
  {
        public User User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
