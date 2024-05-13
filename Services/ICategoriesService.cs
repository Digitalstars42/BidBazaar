using Repositories;

namespace Services
{
    public interface ICategoriesService
    {
        IEnumerable<Categories> Get();
        void Create(Categories category);
    }
}