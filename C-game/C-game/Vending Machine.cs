namespace C_game;

public class VendingMachine()

{
    public void ShowInventory(Inventory inventory)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("These are the available items:");
        Console.ResetColor();
        foreach (string item in inventory.Items)
        {
            Console.WriteLine(item);
        }

        int price = 0;
        do
        {
            Console.WriteLine("What would you like to buy today? Please enter the product number or 'return' to cancel");
            string input = Console.ReadLine();
            price = CheckInput(input, inventory);
            if (price == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter a valid number");
                Console.ResetColor();
            }
            else {

            //wait for user to type number of the product, or "go back" to leave
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"that will be {price} dollar. Would you like to continue your purchase? Type Yes or No");
            Console.ResetColor();
            }
            //if yes, run purchaseItem(). Else go back to selection
        } while (price == 0);
    }


    public int CheckInput(string input, Inventory inventory)
    {
        if (int.TryParse(input, out var inputInt))
        {
            foreach (string item in inventory.Items)
            {
                string[] itemSplit = item.Split(" ");
                int.TryParse(itemSplit[0], out var itemNumber);
                if (itemNumber == inputInt)
                {
                    //To do- return item
                    var lastItem = itemSplit[^1].Split("$");
                    int.TryParse(lastItem[1], out var cost);
                    return cost;
                }
            }
        }

        return 0;
    }

    public void purchaseItem(User user)
    {
        //will make proper function for this later
        if (user.Money >= 10)
        {
            Console.WriteLine("Thank you for your purchase. here is your item.");
            //put item in inventory
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("i'M SORRY, YOU DON'T HAVE ENOUGH MONEY FOR THAT");
            Console.ResetColor();
            //return to program.cs
        }

    }
}
