using LAB_OOP3.Entity;

namespace LAB_OOP3.Repository.IRepository;

public interface IPlayerRepository
{
    void CreatePlayer(PlayerEntity player);
    PlayerEntity ReadPlayerById(int playerId);
    IEnumerable<PlayerEntity> ReadAllPlayers();
    
    void CreateAccount(PlayerEntity player);
    IEnumerable<PlayerEntity> ReadAccounts();
    PlayerEntity ReadAccountById(int playerId);
    void UpdateRating(int playerId, decimal newRating);
}