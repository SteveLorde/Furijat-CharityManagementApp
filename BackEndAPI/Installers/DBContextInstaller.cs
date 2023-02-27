using BackEndAPI.Data.Interfaces;
using BackEndAPI.Data;
using BackEndAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndAPI.Installers
{
    public class DBContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var xxxx = configuration.GetConnectionString("FurijatConnection");
            services.AddDbContext<FurijatContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("FurijatConnection"));
            });

            services.AddScoped<IAppDbContext>(provider =>
                        new ScopedDbContext(provider.GetService<FurijatContext>(),
                        provider.GetService<IHttpContextAccessor>()));
        }
    }
}
