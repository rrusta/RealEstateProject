using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RealEstate.Domain.IdentityModels;
using RealEstate.Domain.Models;
using RealEstate.Infrastructure.Data.Interfaces;
using RealEstate.Infrastructure.Data.Repositories;
using RealEstate.Application.Interfaces;
using RealEstate.Application.Services;
using RealEstate.Domain.Context;

namespace RealEstate.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer 
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProclamationTypesService, ProclamationTypesService>();

            //Infrastructure.Data Layer
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IProclamationTypesRepository, ProclamationTypesRepository>();


            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../RealEstate.API/appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("RealEstateDBConnection");

            services.AddDbContext<RealEstateDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<RealEstateDBContext>()
            .AddDefaultTokenProviders();
        }
    }
}
