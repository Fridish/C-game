using System.IO.Pipes;

namespace C_game;

public class VendingMachine()
{
    public User Customer { get; set; }
    public Inventory Products { get; set; }

//display products in the inventory
    public string InitiateApp()
    {

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("     A. Check your bank account");
        Console.WriteLine("     B. See available goods");
        Console.WriteLine("     C. Exit App");
        var answer = "";
        return answer;
    }

    public string ReadAnswer(string answer)
    {
        do
        {
            answer = Console.ReadLine().ToUpper();
            if (answer == "A")
            {
                return answer;
            }

            if (answer == "B")
            {
                
                return answer;
            }
            else if (answer != "C")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please type A, B or C");
                Console.ResetColor();
            }
        } while (answer != "C");

        return answer;
    }

    public int ShowInventory()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("These are the available items:");
        Console.ResetColor();
        foreach (string item in Products.Items)
        {
            Console.WriteLine(item);
        }

        var input = "";
        do
        {
            Console.WriteLine(
                "What would you like to buy today? Please enter the product number or 'return' to cancel");
            input = Console.ReadLine().ToUpper();
            // if the user types return, return to start page.
            if (input == "RETURN")
            {
                return 0;
            }
            // if user typed a number between 1 and 10, see what goods they want to buy
            else if (int.TryParse(input, out var inputInt) && inputInt > 0 && inputInt < 10)
            {
                return inputInt;
            }

            Console.WriteLine("Please enter a valid answer");
        } while (input != "RETURN");

        return 0;
    }


    public (string, int) ChooseProduct(int input)
    {
        foreach (string item in Products.Items)
        {
            string[] itemSplit = item.Split(" ");
            int.TryParse(itemSplit[0], out var itemNumber);
            if (itemNumber == input)
            {
                // make price and item into their own variable and send it forth.
                var lastItem = itemSplit[^1].Split("$");
                Console.WriteLine(lastItem[1]);
                int.TryParse(lastItem[1], out var cost);
                string[] productArray = itemSplit[1..^1];
                string product = string.Join(" ", productArray);
                Console.WriteLine(product);
                if (Customer.Money < cost)
                {
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("i'M SORRY, YOU DON'T HAVE ENOUGH MONEY FOR THAT");
                        Console.ResetColor();
                        return ("return", 0);
                        //return to program.cs
                    }
                }
                return(product,cost);
            }
        }

        return ("return", 0);
    }

    public (string, int) BuyItem(string product, int cost)
    {
        string input = "";
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"that will be {cost} dollar. Would you like to continue your purchase? Type Yes or No");
            Console.ResetColor();
            input = Console.ReadLine().ToUpper();
            if (input == "YES")
            {
                Console.WriteLine("Thank you for your purchase. here is your item.");
                return (product,cost); 
            }

            if (input == "NO")
            {
                return ("return", 0);
            }

        } while (input != "YES" || input != "NO");
        return (product, cost);
    }
   
}