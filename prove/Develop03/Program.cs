using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); // This will clear the console
        Reference reference = new Reference();
        reference.LoadReference();
        Scripture scripture = new Scripture();
        scripture.LoadScriptures();
        Word word = new Word();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n->->-> Welcome to the Scripture Memorizer App <-<-<-\n");
        Console.ResetColor();

        int userChoice = 0;

        while (userChoice != 2)
        {
            userChoice = UserChoice();

            switch (userChoice)
            {
                case 1:
                    string script = scripture.RandomScripture();
                    string refer = reference.GetReference(scripture);
                    word.GetRenderedText(scripture);
                    word.GetRenderedRef(scripture);

                    while (word._hidden.Count < word._result.Length)
                    {
                        word.Show(refer);
                        word.GetReadKey();
                    }
                    word.Show(refer);
                    break;
                case 2:
                    Console.Clear(); // This will clear the console
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n->->-> Thanks for playing! <-<-<-\n");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry the option you entered is not valid!");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static int UserChoice()
    {
        Reference reference = new Reference();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\n====================================================\n");
        Console.Write("     Please select one of the following choices:");
        Console.ResetColor();
        Console.Write("\n     [1]  Randomly select a scripture\n");
        Console.Write("     [Q]  Quit\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("====================================================\n");
        Console.Write("     What would you like to do? ");
        Console.ResetColor();
        string choices = "";

        Console.Write(choices);

        string userInput = Console.ReadLine();
        userInput.ToLower();
        int userChoice = 0;
        // This block catches any non integer values that are entered
        try
        {
            if (userInput == "q")
            {
                userInput = "2";
            }
            userChoice = int.Parse(userInput);
        }
        catch (FormatException)
        {
            userChoice = 0;
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Unexpected error: {exception.Message}");
            Console.ResetColor();
        }
        return userChoice;
    }
}