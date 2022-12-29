using CleanArchitecture_DDD_DinerApp.Domain.Entities;

namespace CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Authentication;

public interface IjwtTokenGenerator
{
    string GenerateToken(User user);
};
