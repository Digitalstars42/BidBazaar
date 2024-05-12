using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace BidBazaar_project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidsController : ControllerBase
    {
        private readonly ILogger<BidsController> _logger;
        private IBidRepository _repository;
        private readonly IConfiguration _configuration;
        private IBidsService _bidsService;

        public BidsController(ILogger<BidsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _repository = new BidRepository();
            _bidsService = new BidsService(_repository);
            _configuration = configuration;
        }

        [HttpGet(Name = "Bids")]
        public IEnumerable<Bids> Get()
        {
            var connection = _configuration.GetConnectionString("myconnection");
            return _bidsService.Get();
        }
        [HttpPost(Name = "Bids")]
        public ActionResult Create([FromBody] Bids body)
        {
            try
            {
                var connection = _configuration.GetConnectionString("myconnection");
                _bidsService.Create(body);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
