namespace C_game;
//this is the bank that manages how much money the user has to put in the vending machine
public class Bank ()
{
    public User UserAccount { get; set; }
    public void SeeFunds(User UserAccount)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"you have ${UserAccount.Money} left in your account.");
        Console.ResetColor();
    }

    public void PurchaseItem(string product, int price)
    {
        Console.WriteLine("this is the bank");
    }
}