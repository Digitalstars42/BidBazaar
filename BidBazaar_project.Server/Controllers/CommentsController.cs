using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace BidBazaar_project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private ICommentRepository _repository;
        private readonly IConfiguration _configuration;
        private ICommentsService _commentsService;

        public CommentsController(ILogger<CommentsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _repository = new CommentRepository();
            _commentsService = new CommentsService(_repository);
            _configuration = configuration;
        }

        [HttpGet(Name = "Comments")]
        public IEnumerable<Comments> Get()
        {
            var connection = _configuration.GetConnectionString("myconnection");
            return _commentsService.Get();
        }
        [HttpPost(Name = "Comments")]
        public ActionResult Create([FromBody] Comments body)
        {
            try
            {
                var connection = _configuration.GetConnectionString("myconnection");
                _commentsService.Create(body);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
