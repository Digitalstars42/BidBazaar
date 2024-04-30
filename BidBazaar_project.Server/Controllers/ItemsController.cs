using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace BidBazaar_project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private IItemRepository _repository;
        private readonly IConfiguration _configuration;
        private IItemsService _itemsService;

        public ItemsController(ILogger<ItemsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _repository = new ItemRepository();
            _itemsService = new ItemsService(_repository);
            _configuration = configuration;
        }

        [HttpGet(Name = "Items")]
        public IEnumerable<Items> Get()
        {
            var connection = _configuration.GetConnectionString("myconnection");
            return _itemsService.Get();
        }
        [HttpPost(Name = "Items")]
        public ActionResult Create([FromBody] Items body)
        {
            try
            {
                var connection = _configuration.GetConnectionString("myconnection");
                _itemsService.Create(body);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
