// See https://aka.ms/new-console-template for more information
// this is the vending machine 
using C_game;

var user = new User()
{
    Money = 100,
    BoughtItems = new List<string>(),
};
var bank = new Bank();

var inventory = new Inventory()
{
    Items = new List<string>
    {
        "1 Soda $4",
        "2 Chocolate $2",
        "3 Crisps $4",
        "4 Unicorn $78",
        "5 Car Keys $23",
        "6 Earth Bound (SNES) $40",
        "7 Cinema Tickets $20",
        "8 The Room (DVD) $65",
        "9 Triss-scratch Ticket $3"
    }
};
var vendingMachine = new VendingMachine();
Console.WriteLine("Welcome to The Fantastic Vending Machine.");
Console.WriteLine("What would you like to do?");
Console.WriteLine("     A. Check your bank account");
Console.WriteLine("     B. See available goods");
var answer = "";
ReadAnswer(answer);



    void ReadAnswer(string prompt)
    {
        do
        {
            answer = Console.ReadLine().ToUpper();
            if (answer == "A")
            {
                goToBank();
            }

            if (answer == "B")
            {
                goToInventory();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please type A or B");
                Console.ResetColor();
            }
        } while (answer != "A" && answer != "B");
    }

 void goToBank()
 {
     bank.SeeFunds(user);

 }

 void goToInventory()
 {
     vendingMachine.ShowInventory(inventory);
     
 }
