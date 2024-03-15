// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;

class DatabaseApplication
{
    public List<string> Database { get; } = new List<string>();
    public List<string> Commands { get; } = new List<string>
    {
        "add",
        "help",
        "list",
        "delete",
        "quit"
    };

    public DatabaseApplication()
    {
        Load();
    }
    public void Save(string list)
    {
        var file = @"C:\Users\frida\database.txt";
        File.AppendAllLines(file, new List<string> { list });
    }

    public void Load()
    {
        var file = @"C:\Users\frida\database.txt";
        var list = new List<string>();
        if (File.Exists(file))
        {
            list = File.ReadAllLines(file).ToList();
            foreach (var company in list) {
                Database.Add(company);
            }
           
        }
    }
    public void Run()
    {
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("*** Welcome to Initech Data Systems 1.0 ***");
        Console.WriteLine();
        Console.ResetColor();

        string command;

        do
        {
            command = GetCommand();

            if (command == "add")
            {
                Console.WriteLine("Please input company name to add:");
                string company = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(company) )
                {
                    Console.WriteLine();
                }

                if (CompanyExists(company))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{company} already exists in the database!");
                    Console.ResetColor();
                }
                else
                {
                   Database.Add(company); 
                Console.WriteLine($"{company} added to the database!");
                Save(company);
                }
            }
            else if (command == "help")
            {
                Console.WriteLine("-- Available commands --");
                foreach (var listItem in Commands)
                {
                    Console.WriteLine(listItem); 
                }
                
            }
            else if (command == "list")
            {
                foreach (string item in Database)
                {
                    Console.WriteLine(item);
                }
            }
            else if (command == "delete")
            {
                Console.WriteLine("enter company to delete");
                string company = Console.ReadLine();
                if (company == "")
                {
                    Console.WriteLine();
                }
                else if (Database.Contains(company))
                {
                            Database.Remove(company);
                            Console.WriteLine($"{company} removed from database!");
                }
                else
                {
                    Console.WriteLine("Company does not exist in database!");
                }
            }

        } while (command != "quit");
    }

    protected bool CompanyExists( string company)
    {
        foreach (var listItem in Database)
        {
            if (String.Equals(company, listItem, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
    public string GetCommand()
    {
        while (true)
        {
            Console.Write("Please input a command, or \"help\": ");

            var input = Console.ReadLine()!;

            if (Commands.Contains(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.WriteLine();
                Console.ResetColor();

                return input;
            }

            Console.WriteLine("?");
            Console.WriteLine();
        }
    }
}