﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksEverywhere.Models.ApplicationDbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Commands
            // dotnet ef migrations add InitialCreate
            // dotnet ef database update
            // 'ef migrations remove'
            #endregion

            optionsBuilder.UseMySql($"Server=localhost;Port=3306;Database=books_everywhere;user=root;password=12345;Pooling=true;CharSet=utf8;");
            //optionsBuilder.UseMySql($"Server=books-everywhere.cdplvfbgl805.us-east-1.rds.amazonaws.com;Port=3306;Database=innodb;user=admin;password=BoOkSEvErYwHeRe576&;Pooling=true;CharSet=utf8;");
        }
    }
}
