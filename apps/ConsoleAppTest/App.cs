using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Services;

namespace ConsoleAppTest;

public class App
{
    private readonly IDateTime _dateTimeService;
    private readonly IDetailRepository<Detail> _detailRepository;

    public App(IDateTime dateTimeService, IDetailRepository<Detail> detailRepository)
    {
        _dateTimeService = dateTimeService;
        _detailRepository = detailRepository;
    }
    public async Task Run(string[] args)
    {
        Console.WriteLine($"Hello world from App: {_dateTimeService.NowLocalTime}");
        try
        {
            var result = await _detailRepository.Find(w => w.Id == new Guid("6d0d3a94-059e-481e-bf91-f3d65144af59"),
                new CancellationToken());

            Console.WriteLine($"Number of rows {result.Count()}");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }
}