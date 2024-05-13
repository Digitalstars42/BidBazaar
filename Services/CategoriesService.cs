using Repositories;

namespace Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoryRepository _repository;
        public CategoriesService(ICategoryRepository _categoryRepository)
        {
            _repository = _categoryRepository;
        }
        public IEnumerable<Categories> Get()
        {
            return _repository.Get();
        }
        public void Create(Categories category)
        {
            _repository.Create(category);
        }
    }
}
