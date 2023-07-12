using System;
using HangmanGame;

public class GameMenu : Menu
{
    // Attributes 
    private string _menu = $@"
                Game Options
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
Chooce One Option:
1. Random Words
2. Pick your word topic
3. Back to Main Menu
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
Which game would you like to play? ";

    // Constructors

    // Methods
    public override void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(_menu);
    }

    public override void MenuChoice()
    {
        // Call ListMenu
        Menu listMenu = new ListMenu();

        while (_action != 3)
        // switch case for goals menu
        {
            _action = UserChoice();
            Console.ResetColor();
            switch (_action)
            {
                case 1: // Random Words
                    // start game
                    _wordFileName = "words.txt";
                    Hangman game = new Hangman();
                    game.StartGame(_wordFileName);
                    break;
                case 2: // Pick your word topic
                    Console.Clear();  // This will clear the console
                    listMenu.MenuChoice();
                    break;
                case 3: // Back to Main Menu
                    Console.Clear(); // This will clear the console
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry the option you entered is not valid!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();  // This will clear the console
                    break;
            }
        }
    }
}
