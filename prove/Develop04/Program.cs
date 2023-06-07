using System;

class Program
{
    // Attributes 
    static string _menu = $@"
    Menu Options

    ===========================================
    Please select one of the following options:
    1. Start breathing activity
    2. Start reflecting activity
    3. Start listing activity
    4. Quit
    ===========================================
    Select an option from the menu:  ";

    static string _userInput;
    static int _userChoice = 0;

    // Methods
    static int UserChoice()
    // Method to display choices to user
    {
        Console.Clear(); // This will clear the console
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(_menu);
        Console.ResetColor();

        _userInput = Console.ReadLine();

        // This block catches any non integer values that are entered
        try
        {
            _userChoice = int.Parse(_userInput);
        }
        catch (FormatException)
        {
            _userChoice = 0;
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Unexpected error:  {exception.Message}");
            Console.ResetColor();
        }
        return _userChoice;
    }

    static void Main(string[] args)
    {
        // This will clear the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n->->-> Welcome to the Mindfulness Program <-<-<-\n");
        Console.ResetColor();

        int seconds;
        int userAction = 0;

        while (userAction != 4)
        {
            // Ask for user input
            userAction = UserChoice();
            switch (userAction)
            {
                case 1: // Start Breathing Activity
                    Console.Clear();
                    BreathingActivity breathing = new BreathingActivity("Breathing", 0);
                    breathing.GetActivityName();
                    breathing.GetActivityDescription();
                    seconds = breathing.GetActivityTime();
                    breathing.GetReady();
                    breathing.Breathing(seconds);
                    breathing.GetDone();
                    break;
                case 2: //Start Reflecting Activity
                    Console.Clear();
                    ReflectingActivity reflecting = new ReflectingActivity("Reflecting", 0);
                    reflecting.GetActivityName();
                    reflecting.GetActivityDescription();
                    seconds = reflecting.GetActivityTime();
                    reflecting.GetReady();
                    reflecting.ShowPrompt(seconds);
                    reflecting.GetDone();
                    break;
                case 3: //Start Listing Activity
                    Console.Clear();
                    ListingActivity listing = new ListingActivity("Listing", 0);
                    listing.GetActivityName();
                    listing.GetActivityDescription();
                    seconds = listing.GetActivityTime();
                    listing.GetReady();
                    listing.ReturnPrompt(seconds);
                    listing.GetDone();
                    break;
                case 4: // Quite
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThank you for using the Mindfulness Program!\n");
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

}