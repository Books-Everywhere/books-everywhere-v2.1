using System;

namespace BooksEverywhere.Models
{
  public class Publisher
    {
        public int IdPublisher { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }

        Publisher()
        {
            CreateAt = DateTime.Now;
        }
    }
}
