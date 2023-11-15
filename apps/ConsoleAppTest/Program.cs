// See https://aka.ms/new-console-template for more information

using ConsoleAppTest;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// create hosting object and DI layer
using IHost host = CreateHostBuilder(args).Build();
// create a service scope
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;
try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddInfrastructure();
            services.AddSingleton<App>();
        });
}