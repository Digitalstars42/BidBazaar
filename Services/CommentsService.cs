using Repositories;

namespace Services
{
    public class CommentsService : ICommentsService
    {
        private ICommentRepository _repository;
        public CommentsService(ICommentRepository _commentRepository)
        {
            _repository = _commentRepository;
        }
        public IEnumerable<Comments> Get()
        {
            return _repository.Get();
        }
        public void Create(Comments comment)
        {
            _repository.Create(comment);
        }
    }
}
