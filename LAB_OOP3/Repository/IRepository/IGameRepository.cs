using LAB_OOP3.Entity.GameEntities;

namespace LAB_OOP3.Repository.IRepository;

public interface IGameRepository
{
    void CreateGame(GameEntity game);
    GameEntity ReadGameById(int gameId);
    IEnumerable<GameEntity> ReadAllGames();
}