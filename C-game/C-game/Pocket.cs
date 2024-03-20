namespace C_game;

public class Pocket
{
    public User UserItems { get; set; }

    
    //if item is bought, add it to the users pocket
    public void AddItem(string product)
    {
        UserItems.BoughtItems.Add(product);
    }
    
    
    // display the items the user has bought and the amount of each item
    public static void SeeBoughtItems( User user)
    {
        var checkedItems = new List<string>();
        var countItems = new List<int>();
        var items = user.BoughtItems;
        if (items.Count > 0)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You currently own:");
            Console.ResetColor();
            var countedItems = items.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            foreach (var item in countedItems)
            {
                Console.WriteLine($"{item.Value}x {item.Key}");
            }
           
        } 
        else 
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("you currently don't own any items.");
        Console.ResetColor();
        }
    }
}