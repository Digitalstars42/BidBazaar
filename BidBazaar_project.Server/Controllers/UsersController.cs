using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _repository = new UserRepository();
            _usersService = new UsersService(_repository);
            _configuration = configuration;
        }

        [HttpGet(Name = "Users")]
        public IEnumerable<Users> Get()
        {
            var connection = _configuration.GetConnectionString("myconnection");
            return _usersService.Get();
        }
        [HttpPost(Name = "Users")]
        public ActionResult Create([FromBody] Users body)
        {
            try
            {
                var connection = _configuration.GetConnectionString("myconnection");
                _usersService.Create(body);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
