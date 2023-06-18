using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Models;
using BackEndAPI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndAPI.Installers
{
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configure AutoMapper
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Charity, CharityDTO>();
                cfg.CreateMap<CharityDTO, Charity>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            }).CreateMapper());
        }
    }
}
