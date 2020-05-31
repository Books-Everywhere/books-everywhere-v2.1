using Microsoft.AspNetCore.Identity;
using System;

namespace BooksEverywhere.Models
{
  public class User : IdentityUser
  {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatAt { get; set; }
        public bool Enabled { get; set; }
        public Guid Token { get; set; }

        User() 
        {
            CreatAt = DateTime.Now;
            Enabled = true;
        }
    }
}
