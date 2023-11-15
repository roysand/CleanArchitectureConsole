using Application.Common.Interface;
using Infrastructure.Services;

namespace ConsoleAppTest;

public class App
{
    private readonly IDateTime _dateTimeService;

    public App(IDateTime dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }
    public void Run(string[] args)
    {
        Console.WriteLine($"Hello world from App: {_dateTimeService.NowLocalTime}");
    }
}