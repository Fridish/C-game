namespace C_game;

// this is the vending machine where the user can buy goods that are in the "products" class
public class Vending_Machine(int money)
{
    public int Money { get; set; }
    public void ListItems()
    {
        Console.WriteLine("These are the available items:");
        //display all items and their cost 
        Console.WriteLine("What would you like to buy today?");
        //wait for user to type number of the product, or "go back" to leave
        Console.WriteLine("that will be x dollar. Would you like to continue your purchase?"); 
        //if yes, run purchaseItem(). Else go back to selection
    }

    public void purchaseItem()
    {
        if (money >= 10){
        Console.WriteLine("Thank you for your purchase. here is your item.");
        //put item in inventory
        }
        else
        {
            Console.WriteLine("i'M SORRY, YOU DON'T HAVE ENOUGH MONEY FOR THAT");
            //return to program.cs
        }
        }
    
}