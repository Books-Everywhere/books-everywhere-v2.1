using System;

namespace BooksEverywhere.Models
{
    public class Publisher
    {
        public virtual int IdPublisher { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreateAt { get; set; }

        public Publisher()
        {
            CreateAt = DateTime.Now;
        }
    }
}
