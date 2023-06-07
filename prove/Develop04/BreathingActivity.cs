using System;

public class BreathingActivity : Activity
{

    // Attributes 
    private string _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    private string _message1 = "Breathe in... ";
    private string _message2 = "Now breathe out... ";
    

    // Constructors
    public BreathingActivity(string activityName, int activityTime) : base(activityName, activityTime)
    {
    }

    public void GetActivityDescription()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(_description);
        Console.ResetColor();
    }

    public void Breathing(int seconds)
    {
        Console.WriteLine();  //insert a blank line to start
        int secondsTimer = 0;
        while (secondsTimer < seconds)
        {
            Console.WriteLine();  //insert a blank line to start
            for (int i = 5; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{_message1}{i}");
                Thread.Sleep(1000);
                string blank = new string('\b', (_message1.Length + 2));
                Console.Write(blank);
                secondsTimer += 1;
                
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{_message1}  ");
            for (int i = 5; i > 0; i--)
            {
                Console.Write($"{_message2}{i}");
                Thread.Sleep(1000);
                string blank = new string('\b', (_message2.Length + 2));
                Console.Write(blank);
                secondsTimer += 1;
            }
            Console.WriteLine($"{_message2}  \n");
            Console.ResetColor();
        }
    }

}