using System;

namespace BooksEverywhere.Models
{
    public class Publisher
    {
        public virtual int IdPublisher { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public Publisher()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
