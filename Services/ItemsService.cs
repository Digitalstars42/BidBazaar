using Repositories;

namespace Services
{
    public class ItemsService : IItemsService
    {
        private IItemRepository _repository;
        public ItemsService(IItemRepository _itemRepository)
        {
            _repository = _itemRepository;
        }
        public IEnumerable<Items> Get()
        {
            return _repository.Get();
        }
        public void Create(Items item)
        {
            _repository.Create(item);
        }
    }
}
