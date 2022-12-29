namespace CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Services;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
