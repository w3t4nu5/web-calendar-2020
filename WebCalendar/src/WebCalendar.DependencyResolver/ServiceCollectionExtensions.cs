using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebCalendar.Common;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL;
using WebCalendar.DAL.EF;
using WebCalendar.DAL.EF.Context;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.DAL.Repositories.Contracts;
using WebCalendar.DAL.Repositories.Implementation;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Implementation;

namespace WebCalendar.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration["ConnectionString"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection,
                    builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); }));

            services.AddDefaultIdentity<User>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<IDataInitializer, EFDataInitializer>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepositoryAsync<>));

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IMapper, WebCalendarAutoMapper>();
        }
    }
}