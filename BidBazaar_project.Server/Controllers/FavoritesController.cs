using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace BidBazaar_project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly ILogger<FavoritesController> _logger;
        private IFavoriteRepository _repository;
        private readonly IConfiguration _configuration;
        private IFavoritesService _favoritesService;

        public FavoritesController(ILogger<FavoritesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _repository = new FavoriteRepository();
            _favoritesService = new FavoritesService(_repository);
            _configuration = configuration;
        }

        [HttpGet(Name = "Favorites")]
        public IEnumerable<Favorites> Get()
        {
            var connection = _configuration.GetConnectionString("myconnection");
            return _favoritesService.Get();
        }
        [HttpPost(Name = "Favorites")]
        public ActionResult Create([FromBody] Favorites body)
        {
            try
            {
                var connection = _configuration.GetConnectionString("myconnection");
                _favoritesService.Create(body);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
