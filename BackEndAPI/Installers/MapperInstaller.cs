﻿using AutoMapper;
using BackEndAPI.Data.Entites;
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
                cfg.CreateMap<CaseDTO, Case>();
                cfg.CreateMap<Case, CaseDTO>();
                cfg.CreateMap<DonatorDTO, Donator>();
                cfg.CreateMap<Donator, DonatorDTO>();
                cfg.CreateMap<PaymentToCreditorDTO, PaymentToCreditor>();
                cfg.CreateMap<PaymentToCreditor, PaymentToCreditorDTO>();
                cfg.CreateMap<DonationDTO, Donation>();
                cfg.CreateMap<Donation, DonationDTO>();
                cfg.CreateMap<Creditor, CreditorDTO>();
                cfg.CreateMap<CreditorDTO, Creditor>();
            }).CreateMapper());
        }
    }
}
