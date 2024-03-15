namespace C_game;
//this is the bank that manages how much money the user has to put in the vending machine
public class Bank ()
{
    public void SeeFunds(User user)
    {
        Console.WriteLine($"you have ${user.Money} left in your account.");
    }
}