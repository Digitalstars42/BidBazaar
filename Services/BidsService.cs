using Repositories;

namespace Services
{
    public class BidsService : IBidsService
    {
        private IBidRepository _repository;
        public BidsService(IBidRepository _bidRepository)
        {
            _repository = _bidRepository;
        }
        public IEnumerable<Bids> Get()
        {
            return _repository.Get();
        }
        public void Create(Bids bid)
        {
            _repository.Create(bid);
        }
    }
}
