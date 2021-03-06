using Microsoft.AspNetCore.Identity;
using System;

namespace BooksEverywhere.Models
{
    public class User : IdentityUser
    {
        public virtual int IdUser { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Gender { get; set; }
        public string Password { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual bool Enabled { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
            Enabled = true;
        }
    }
}
