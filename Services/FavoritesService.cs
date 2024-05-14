using Repositories;

namespace Services
{
    public class FavoritesService : IFavoritesService
    {
        private IFavoriteRepository _repository;
        public FavoritesService(IFavoriteRepository _favoriteRepository)
        {
            _repository = _favoriteRepository;
        }
        public IEnumerable<Favorites> Get()
        {
            return _repository.Get();
        }
        public void Create(Favorites favorite)
        {
            _repository.Create(favorite);
        }
    }
}
