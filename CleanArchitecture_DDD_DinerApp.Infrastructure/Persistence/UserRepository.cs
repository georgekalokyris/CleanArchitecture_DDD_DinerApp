using CleanArchitecture_DDD_DinerApp.Application.Common.Interfaces.Persistence;
using CleanArchitecture_DDD_DinerApp.Domain.Entities;

namespace CleanArchitecture_DDD_DinerApp.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new ();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
      return _users.SingleOrDefault(x=>x.Email == email);
    }
}
