using Repositories;

namespace Services
{
    public interface IItemsService
    {
        IEnumerable<Items> Get();
        void Create(Items item);
    }
}