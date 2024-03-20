namespace C_game;
//this is the bank that manages how much money the user has to put in the vending machine
public class Bank ()
{
    public User UserAccount { get; set; }
    
    //display the users' funds
    public void SeeFunds(User UserAccount)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"you have ${UserAccount.Money} left in your account.");
        Console.ResetColor();
    }

    // withdraw the money form the account
    public void PurchaseItem( int price)
    {
     
        UserAccount.Money -= price;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine();
        Console.WriteLine($"Your current balance is ${UserAccount.Money}");
        Console.ResetColor(); 
    }
}