using LAB_OOP3.Entity;
using LAB_OOP3.Entity.GameEntities;

namespace LAB_OOP3;

public class DbContext
{
    public List<PlayerEntity> Players { get; } = new();
    public List<GameEntity> Games { get; } = new();
}