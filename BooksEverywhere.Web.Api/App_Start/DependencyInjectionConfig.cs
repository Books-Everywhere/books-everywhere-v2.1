using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Repositories;
using BooksEverywhere.Repositories.Infra;
using BooksEverywhere.Services;
using BooksEverywhere.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BooksEverywhere.Web.Api.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            #region UnitOfWork & DbConfig
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbConfig, DbConfig>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
