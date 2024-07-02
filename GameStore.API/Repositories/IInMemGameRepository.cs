using GameStore.API.Entities;

namespace GameStore.API.Repositories
{
    public interface IInMemGameRepository
    {
        void Create(Game game);
        void Delete(int id);
        Game? Get(int id);
        IEnumerable<Game> GetAll();
        void Update(Game updatedGame);
    }
}