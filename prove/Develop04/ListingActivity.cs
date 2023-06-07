using System;
using System.Diagnostics;

public class ListingActivity : Activity
{

    // Attributes 
    private List<string> _promptList = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _userList = new List<string>();
    private string _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    public ListingActivity(string activityName, int activityTime) : base(activityName, activityTime)
    {
    }

    public void GetActivityDescription()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(_description);
        Console.ResetColor();
    }

    private string GetRandomPrompt()
    {
        var random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }

    public void ReturnPrompt(int seconds)
    {
        Console.WriteLine();  //insert blank line to start
        var question = GetRandomPrompt();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\n->->-> {question} <-<-<-");
        Console.ResetColor();
        CountDown(8);
        Timer(seconds);
    }

    public void Timer(int seconds)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        while (timer.Elapsed.TotalSeconds < seconds)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("> ");
            _userList.Add(Console.ReadLine());
            Console.ResetColor();
        }

        timer.Stop();
        int listLength = _userList.Count;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nYou listed {listLength} items!\n");
        Console.ResetColor();
    }

}