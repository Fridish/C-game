using System.IO.Pipes;

namespace C_game;

public class VendingMachine()
{
    public User Customer { get; set; }
    public Inventory Products { get; set; }
    
    
    // Initiate the app in the vending machine
    public string InitiateApp()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("What would you like to do?");
        Console.ResetColor();
        Console.WriteLine("     A. Check your bank account");
        Console.WriteLine("     B. See your bought goods");
        Console.WriteLine("     C. See available goods");
        Console.WriteLine("     D. Exit App");
        var answer = "";
        return answer;
    }

    // read what the user answers
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

            if (answer == "C")
            {
                return answer;
            }
            if (answer != "D")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please type A, B, C or D");
                Console.ResetColor();
            }
        } while (answer != "D");

        return answer;
    }

    
    // display all items for sale. Unlimited ammount of items
    public int ShowInventory()
    {
        Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine("Please enter a valid answer");
        } while (input != "RETURN");

        return 0;
    }


    //display the chosen product and make sure the user can afford it
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
                int.TryParse(lastItem[1], out var cost);
                string[] productArray = itemSplit[1..^1];
                string product = string.Join(" ", productArray);
                    Console.WriteLine(product);
                if (Customer.Money < cost)
                {
                    {
                        Console.WriteLine();
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

    
    // if the user can afford the item, ask if they want to complete the purchase
    public (string, int) BuyItem(string product, int cost)
    {
        string input = "";
        do
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"that will be ${cost}. Would you like to continue your purchase? Type Yes or No");
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

    
    // ask user if they want to buy something else or return to start menu.
    public int BuyMore()
    {
        string answer;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Would you like ot buy something else? Yes/No");
            answer = Console.ReadLine().ToUpper();
            if (answer == "YES")
            {
                return 1;
            }
            else if (answer == "NO")
            {
                return 0;
            }
        } 
        while (answer != "YES" || answer != "NO");
        return 0;
    }
   
}