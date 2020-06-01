using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksEverywhere.Models.ApplicationDbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // -> commands to create the migrations:
            // dotnet ef migrations add InitialCreate
            // dotnet ef database update
            // 'ef migrations remove'
            optionsBuilder.UseMySql($"Server=localhost;Port=3306;Database=books_everywhere;user=root;password=lunashakira8;Pooling=true;");
        }
    }
}
