// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to The Fantastic Vending Machine.");
Console.WriteLine("What would you like to do?");
Console.WriteLine("     A. Check your bank account");
Console.WriteLine("     B. See available goods");
string answer = "";
 ReadAnswer(answer);


   string ReadAnswer(string prompt)
 {
     do
    {
        answer = Console.ReadLine().ToUpper();
        if (answer == "A")
        {
            return answer = "A. Check Bank Account";
        }

        if (answer == "B")
        {
            return answer = "B. See available goods";
        }
        else
        {
            Console.WriteLine("please type A or B");
            continue;
        }
    } while (answer != "A" && answer != "B");

     return answer;
 }
 Console.WriteLine(answer);