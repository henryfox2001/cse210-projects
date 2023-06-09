using System;

public class Activity
{
    // Attributes
    private string _activityName;
    private int _activityTime;
    private string _message = "You may begin in... ";
    protected string _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    // Constructors
    public Activity(string activityName, int activityTime)
    {
        _activityName = activityName;
        _activityTime = activityTime;
    }

    public void GetActivityName()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Welcome to the {_activityName} Activity!\n");
        Console.ResetColor();
    }

    public void GetActivityDescription()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(_description);
        Console.ResetColor();
    }

    public void SetActivityName(string activityName)
    {
        _activityName = activityName;
    }

    private static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public int GetActivityTime()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nHow long, in seconds, would you like your session to be? => ");
        Console.ResetColor();

        int userSeconds;
        while (!int.TryParse(Console.ReadLine(), out userSeconds))
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("How long, in seconds, would you like your session to be? => ");
            Console.ResetColor();
        }

        _activityTime = userSeconds;
        return userSeconds;
    }

    public void SetActivityTime(int activityTime)
    {
        _activityTime = activityTime;
    }

    // Methods
    public void GetReady()
    {
        Console.Clear(); // This will clear the console
        Console.ForegroundColor = ConsoleColor.Green;
        Spinner spinner = new Spinner();
        spinner.ShowSpinnerReady();
        Console.Write("Get ready...  ");
        Console.ResetColor();
    }

    public void GetDone()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Spinner spinner = new Spinner();
        spinner.ShowSpinnerFinished();
        Console.WriteLine("Well done!!!  ");
        Console.Write($"\nYou have completed another {_activityTime} seconds of the {_activityName} Activity! ");
        spinner.ShowSpinner();
        Console.ResetColor();
        Console.Clear(); // This will clear the console
    }
     public void CountDown(int time)
    {
        Console.WriteLine();
        for (int i = time; i > 0; i--)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{_message}{i}");
            Console.ResetColor();
            Thread.Sleep(1000);
            string blank = new string('\b', (_message.Length + 5));
            Console.Write(blank);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Go:                                  \n");
        Console.ResetColor();
    }

}