using cleanarchitecture.Domain;

namespace cleanarchitecture.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User GetUserByEmail(string email)
    {
       return _users.SingleOrDefault(u=>u.EMail == email);
    }
}