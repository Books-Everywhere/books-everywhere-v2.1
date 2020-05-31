using BooksEverywhere.Models.Repositories.Interfaces;
using BooksEverywhere.Repositories;
using BooksEverywhere.Services;
using BooksEverywhere.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BooksEverywhere.Web.Api.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            //services.AddScoped<IApplicationContext, ApplicationContext>();

            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
