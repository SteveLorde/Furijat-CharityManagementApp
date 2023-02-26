using BackEndAPI.Data.Interfaces;
using BackEndAPI.Data;
using BackEndAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndAPI.Installers
{
    public class DBContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FurijatContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAppDbContext>(provider =>
                        new ScopedDbContext(provider.GetService<FurijatContext>(),
                        provider.GetService<IHttpContextAccessor>()));
        }
    }
}
