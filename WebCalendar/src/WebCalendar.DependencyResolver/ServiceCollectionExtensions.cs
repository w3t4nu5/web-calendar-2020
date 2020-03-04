using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebCalendar.Common;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL.EF;
using WebCalendar.DAL.EF.Context;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.DAL.Repositories.Contracts;
using WebCalendar.DAL.Repositories.Implementation;

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

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddScoped<IDataInitializer, EFDataInitializer>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepositoryAsync<>));
            
            services.AddSingleton<IMapper, WebCalendarAutoMapper>();
        }
    }
}