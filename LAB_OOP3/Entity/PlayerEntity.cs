using LAB_OOP3.GameAccounts;

namespace LAB_OOP3.Entity;

public class PlayerEntity
{
    public int Id { get; set; }
    public string UserName { get; }
    public decimal CurrentRating { get; set; }
    public GameAccount GameAccount { get; }
    
    public PlayerEntity(GameAccount gameAccount)
    {
        UserName = gameAccount.UserName;
        CurrentRating = gameAccount.CurrentRating;
        GameAccount = gameAccount;
    }
}