using System;

public class ListMenu : Menu
{
    // Attributes 
    private string _menu = $@"
                List Options
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
Your list Options are:
1. Animals
2. Colors
3. Sports
4. Back to Game Menu
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
Which list would you like to use?  ";

    // Constructors

    // Methods
    public override void DisplayMenu()
    {
        Console.Write(_menu);
    }

    public override void MenuChoice()
    {
        while (_action != 4)
        // switch case for list menu
        {
            Hangman game = new Hangman();
            _action = UserChoice();
            switch (_action)
            {
                case 1: // Console.WriteLine("Success Choice 1!");
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4: // Back to Main Menu
                    Console.Clear(); // This will clear the console
                    break;
                default:
                    Console.WriteLine($"\nSorry the option you entered is not valid!");
                    Thread.Sleep(2000);
                    Console.Clear(); // This will clear the console
                    break;
            }
        }
    }
}
