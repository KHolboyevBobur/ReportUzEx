
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reports.Application.Interfaces;

namespace Reports.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence( this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ReportsDbContext>(options=>
            options.UseSqlite(connectionString));   
        services.AddScoped<IReportsDbContext>(provider=>provider.GetService<ReportsDbContext>());

            return services;
        }
    }
}
