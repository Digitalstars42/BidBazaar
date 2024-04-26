using Repositories;

namespace Services
{
    public interface IUsersService
    {
        IEnumerable<Users> Get();
    }
}