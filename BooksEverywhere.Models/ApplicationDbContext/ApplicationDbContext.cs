using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksEverywhere.Models.ApplicationDbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"Server=localhost;Port=3306;Database=BooksEverywhere;user=root;password=lunashakira8;Pooling=true;");
        }
    }
}
