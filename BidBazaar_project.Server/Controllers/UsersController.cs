using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace BidBazaar_project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserRepository _repository;
        private IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _repository = new UserRepository();
            _usersService = new UsersService(_repository);

        }

        [HttpGet(Name = "Users")]
        public IEnumerable<Users> Get()
        {
            return _usersService.Get();
        }
    }
}
