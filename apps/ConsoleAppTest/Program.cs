// See https://aka.ms/new-console-template for more information

using ConsoleAppTest;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("local.settings.json")
    .Build();

// create hosting object and DI layer
using IHost host = CreateHostBuilder(args, configuration).Build();

// create a service scope
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings, IConfiguration configuration)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddInfrastructure();
            services.AddSingleton<App>();
        })
        .ConfigureHostConfiguration(hostConfig =>
        {
            hostConfig.AddConfiguration(configuration);
        });
}