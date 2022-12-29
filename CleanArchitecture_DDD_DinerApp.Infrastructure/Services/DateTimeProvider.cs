using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Services;

namespace CleanArchitecture_DDD_DinerApp.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

}
