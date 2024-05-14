using Repositories;

namespace Services
{
    public interface IFavoritesService
    {
        IEnumerable<Favorites> Get();
        void Create(Favorites favorite);
    }
}