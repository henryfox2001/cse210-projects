using System;
using System.Diagnostics;

public class ReflectingActivity : Activity
{

    // Attributes 
    private List<string> _promptList = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questionList = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _useQuestionsList = new List<string>();

    private string _prompt;
    private string _question;
    private string _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    // Constructors
    // Methods
    public ReflectingActivity(string activityName, int activityTime) : base(activityName, activityTime)
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

    private string GetRandomQuestion()
    {
        var random = new Random();
        int index = random.Next(_useQuestionsList.Count);
        return _useQuestionsList[index];
    }

    public void ShowPrompt(int seconds)
    {
        Console.WriteLine();  //insert blank line to start
        var prompt = GetRandomPrompt();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nConsider the following prompt:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\n->->-> {prompt} <-<-<-");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nWhen you have something in mind, press <Enter> to continue.");
        Console.ResetColor();

        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Enter)
        {
            ShowQuestion(seconds);
        }
    }

    public void ShowQuestion(int seconds)
    {
        _useQuestionsList.AddRange(_questionList); //creates a new list that can be destroyed each time.
        Spinner spinner = new Spinner();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\n->->-> Now ponder on each of the following questions as they related to this experience. <-<-<-");
        Console.ResetColor();
        CountDown(8);
        Console.Clear();
        Stopwatch timer = new Stopwatch();
        timer.Start();
        while (timer.Elapsed.TotalSeconds < seconds)
        {
            if (_useQuestionsList.Count != 0)
            {
                var question = GetRandomQuestion();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\n->->-> {question} <-<-<-\n\n");
                Console.ResetColor();
                _useQuestionsList.Remove(question);  //removes question from list so it can't be used again
            }
            Console.ForegroundColor = ConsoleColor.Green;
            spinner.ShowSpinner();
            Console.Write("  ");
            Console.ResetColor();
        }
        timer.Stop();
    }

}