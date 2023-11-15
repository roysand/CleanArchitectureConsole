using Application.Common.Interface;

namespace Infrastructure.Services;

public class DateTimeService : IDateTime
{
    private readonly string timeZoneId = "Europe/Oslo";
    public DateTime NowUtc => DateTime.UtcNow;
    public DateTime NowLocalTime 
    {
        get
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId); 
            var nowLocalTime = TimeZoneInfo.ConvertTimeFromUtc(NowUtc, timeZone);
            return nowLocalTime;
        }
    }
}