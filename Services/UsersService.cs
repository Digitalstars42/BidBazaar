using Repositories;

namespace Services
{
    public class UsersService : IUsersService
    {
        private IUserRepository _repository;
        public UsersService(IUserRepository _userRepository)
        {
            _repository = _userRepository;
        }
        public IEnumerable<Users> Get()
        {
            return _repository.Get();
        }
        public void Create(Users user)
        {
            _repository.Create(user);
        }
    }
}
