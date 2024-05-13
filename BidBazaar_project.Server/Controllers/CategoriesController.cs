using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace BidBazaar_project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private ICategoryRepository _repository;
        private readonly IConfiguration _configuration;
        private ICategoriesService _categoriesService;

        public CategoriesController(ILogger<CategoriesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _repository = new CategoryRepository();
            _categoriesService = new CategoriesService(_repository);
            _configuration = configuration;
        }

        [HttpGet(Name = "Categories")]
        public IEnumerable<Categories> Get()
        {
            var connection = _configuration.GetConnectionString("myconnection");
            return _categoriesService.Get();
        }
        [HttpPost(Name = "Categories")]
        public ActionResult Create([FromBody] Categories body)
        {
            try
            {
                var connection = _configuration.GetConnectionString("myconnection");
                _categoriesService.Create(body);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
