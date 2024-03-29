﻿using LAB_OOP3.Entity.GameEntities;
using LAB_OOP3.Repository.IRepository;

namespace LAB_OOP3.Repository;

public class GameRepository: IGameRepository
{
    private readonly List<GameEntity> _games;

    public GameRepository(List<GameEntity> games)
    {
        _games = games;
    }

    public void CreateGame(GameEntity game)
    {
        game.Id = _games.Count + 1;
        _games.Add(game);
    }

    public GameEntity ReadGameById(int gameId)
    {
        return _games.FirstOrDefault(g => g.Id == gameId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<GameEntity> ReadAllGames()
    {
        return _games;
    }
}