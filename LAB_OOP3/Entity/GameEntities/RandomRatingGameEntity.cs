﻿namespace LAB_OOP3.Entity.GameEntities;

public class RandomRatingGameEntity : GameEntity
{
    public RandomRatingGameEntity(int playerId)
    {
        Random random = new Random();
        ChangeOfRating = random.Next(5, 11);
        PlayerId = playerId;
    }
}