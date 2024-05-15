using Repositories;

namespace Services
{
    public interface ICommentsService
    {
        IEnumerable<Comments> Get();
        void Create(Comments comment);
    }
}