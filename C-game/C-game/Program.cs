// See https://aka.ms/new-console-template for more information
// this is the vending machine 

using System.Runtime.InteropServices.Marshalling;
using C_game;

//initiate the objects used for the vending machine
var user = new User()
{
    Money = 60,
    BoughtItems = new List<string>(),
};
var bank = new Bank()
{
UserAccount= user
};

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
var vendingMachine = new VendingMachine()
{
    Customer = user,
    Products = inventory,
};

// start the program 
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Welcome to The Fantastic Vending Machine.");
Console.ResetColor();

//Initiate the method that displays the choices.
var answer = "";
do
{
    answer = vendingMachine.InitiateApp();
    answer = vendingMachine.ReadAnswer(answer);
    if (answer == "A")
    {
        bank.SeeFunds(user);
        vendingMachine.InitiateApp();
    }
    else if (answer == "B")
    {
        int choice = vendingMachine.ShowInventory();
        if (choice != 0)
        {
            // make sure to retrieve both variables
            (string product, int price) = vendingMachine.ChooseProduct(choice);
            if (product != "return" && price != 0)
            {
                (product, price) = vendingMachine.BuyItem(product, price);
                bank.PurchaseItem(product, price);
                vendingMachine.InitiateApp();
            }
        }
    }
} while (answer != "C");


