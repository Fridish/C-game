// See https://aka.ms/new-console-template for more information
// this is the vending machine 

using System.Runtime.InteropServices.Marshalling;
using C_game;

//initiate the objects used for the vending machine
var user = new User()
{
    Money = 100,
    BoughtItems = new List<string>(),
};
var bank = new Bank()
{
UserAccount= user
};

var pocket = new Pocket()
{
    UserItems = user
};
var inventory = new Inventory()
{
    Items = new List<string>
    {
        "1 Soda $4",
        "2 Chocolate $2",
        "3 Crisps $4",
        "4 GameCube $78",
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
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Welcome to The Fantastic Vending Machine.");
Console.ResetColor();

//Initiate the method that displays the choices.
var answer = "";
int choice = 1;
do
{
    // initiate app
    answer = vendingMachine.InitiateApp();
    answer = vendingMachine.ReadAnswer(answer);
    if (answer == "A")
    {
        //show the user how much money they have left
        bank.SeeFunds(user);
    }
    else if (answer == "B")
    {
        // show user what goods they have bought
        Pocket.SeeBoughtItems(user);
    } 
    else if (answer == "C")
    {
        do {
            // show inventory to user
            choice = vendingMachine.ShowInventory(); 
            
            // have user select a product or return
            (string product, int price) = vendingMachine.ChooseProduct(choice);
                
                // if user chose a product, and can afford it, continue with purchase
                if (product != "return" && price != 0)
                {
                    // confirm purchase, if user says yes, add it to pocket and remove funds from account 
                    (product, price) = vendingMachine.BuyItem(product, price);
                    if (price != 0)
                    {
                        pocket.AddItem(product);
                        bank.PurchaseItem(price);
                    }
                    
                    // ask user if they want to buy something else, if not, return to menu
                    choice = vendingMachine.BuyMore();
                } 
        }while ( choice !=0);
    } 
} while (answer != "D");



