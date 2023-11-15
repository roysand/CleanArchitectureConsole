using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // sservices.AddTransient<IAppclicationDbContext,ApplicationDbContext>();
        services.AddTransient<ApplicationDbContext>();
        services.AddTransient<IDetailRepository<Detail>, DetailRepository>();
        services.AddSingleton<IDateTime, DateTimeService>();
        services.AddSingleton<IConfig, Config.Config>();
        // services.AddTransient<AMSMqttManagedClient>();
        return services;
    }
}