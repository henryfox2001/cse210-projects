using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string uName = Console.ReadLine();
        return uName;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int uNumber = int.Parse(Console.ReadLine());
        return uNumber;
    }
    static int SquareNumber(int uNumber)
    {
        int sNumber = uNumber * uNumber;
        return sNumber;
    }
    static void DisplayResult(string uName, int sNumber)
    {
        Console.WriteLine($"{uName}, the square of your number is {sNumber}");
    }
}