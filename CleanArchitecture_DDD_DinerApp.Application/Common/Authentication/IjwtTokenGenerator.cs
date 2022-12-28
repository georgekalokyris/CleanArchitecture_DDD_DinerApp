namespace CleanArchitecture_DDD_DinerApp.Application.Common.Authentication;

public interface IjwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
};
