using System.Text;
using LAB_OOP3.Entity;
using LAB_OOP3.Entity.GameEntities;
using LAB_OOP3.GameAccounts;
using LAB_OOP3.Repository;
using LAB_OOP3.Service;

namespace LAB_OOP3
{
    public abstract class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DbContext dbContext = new DbContext();
            PlayerRepository playerRepository = new PlayerRepository(dbContext.Players);
            GameRepository gameRepository = new GameRepository(dbContext.Games);
            IGameService gameService = new GameService(playerRepository, gameRepository);
            
            PlayerEntity player1 = new PlayerEntity(new StandardGameAccount("Bob", 234));
            PlayerEntity player2 = new PlayerEntity(new ReducedLossGameAccount("Alice", 55));
            PlayerEntity player3 = new PlayerEntity(new WinningStreakGameAccount("Nazar", 12));

            gameService.CreateAccount(player1);
            gameService.CreateAccount(player2);
            gameService.CreateAccount(player3);

            GameEntity standardGame1 = new StandardGameEntity(25, player1.Id);
            gameService.CreateGame(standardGame1);

            GameEntity trainingGame1 = new TrainingGameEntity(player1.Id);
            gameService.CreateGame(trainingGame1);
            
            GameEntity randomGame1 = new RandomRatingGameEntity(player1.Id);
            gameService.CreateGame(randomGame1);

            GameEntity standardGame2 = new StandardGameEntity(15, player2.Id);
            gameService.CreateGame(standardGame2);
            
            GameEntity trainingGame2 = new TrainingGameEntity(player2.Id);
            gameService.CreateGame(trainingGame2);
            
            GameEntity  randomGame2 = new RandomRatingGameEntity(player2.Id);
            gameService.CreateGame(randomGame2);

            GameEntity standardGame3 = new StandardGameEntity(30, player3.Id);
            gameService.CreateGame(standardGame3);

            GameEntity trainingGame3 = new TrainingGameEntity(player3.Id);
            gameService.CreateGame(trainingGame3);
            
            GameEntity randomGame3 = new RandomRatingGameEntity(player3.Id);
            gameService.CreateGame(randomGame3);

            Console.WriteLine("List of players:");
            foreach (var player in gameService.ReadAccounts())
            {
                Console.WriteLine($"{player.Id}. {player.UserName} - Rating: {player.CurrentRating}");
            }

            PrintPlayerGamesInfo(gameService, player1);
            PrintPlayerGamesInfo(gameService, player2);
            PrintPlayerGamesInfo(gameService, player3);

            Console.WriteLine("\nList of all games:");
            foreach (var game in gameService.ReadGames())
            {
                PrintGameInfo(gameService, game);
            }
        }
        
        private static void PrintPlayerGamesInfo(IGameService gameService, PlayerEntity player)
        {
            Console.WriteLine($"\nList of games for {player.UserName}:");
            foreach (var game in gameService.ReadPlayerGamesByPlayerId(player.Id))
            {
                PrintGameInfo(gameService, game);
            }
        }
        
        private static void PrintGameInfo(IGameService gameService, GameEntity game)
        {
            var result = gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"| {"Game #",5} | {"Result",6} | {"Rating Change",13} | {"New Rating",10} | {"Game Type",15} |");
                Console.WriteLine($"| {game.Id,5} | {result,6} | {game.ChangeOfRating,13} | {gameService.GetPlayerRating(game.PlayerId),10} | {gameService.GetGameTypeName(game),15} |");
                Console.WriteLine("---------------------------------------------------------------");
        }
    }
}