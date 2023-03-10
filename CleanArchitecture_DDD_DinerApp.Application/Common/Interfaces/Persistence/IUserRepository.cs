using CleanArchitecture_DDD_DinerApp.Domain.Entities;

namespace CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
     User? GetUserByEmail(string email);

     void Add(User user);
}
