using Repositories;

namespace Services
{
    public interface IBidsService
    {
        IEnumerable<Bids> Get();
        void Create(Bids bid);
    }
}