using System;
using System.Diagnostics;

public class Spinner
{

    // Attributes 
    int counter;

    // Methods
    public void Stopwatch()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        while (timer.Elapsed.TotalSeconds < 10)
        {
            Console.Write("+");

            Thread.Sleep(500);

            Console.Write("\b \b");
            Console.Write("-");
        }
        timer.Stop();
    }

    public void ShowSimplePercentage()
    {
        for (int i = 0; i <= 100; i++)
        {
            Console.Write($"\rGet Ready... {i}%   ");
            Thread.Sleep(50);
        }
        Console.Write("\rGet Ready...      ");
    }

    public void ShowSpinner()
    {
        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            counter++;
            Thread.Sleep(100);
        }
    }

    public void ShowSpinnerReady()
    {
        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            switch (counter % 4)
            {
                case 0: Console.Write("Get ready... /"); break;
                case 1: Console.Write("Get ready... -"); break;
                case 2: Console.Write("Get ready... \\"); break;
                case 3: Console.Write("Get ready... |"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 14, Console.CursorTop);
            counter++;
            Thread.Sleep(75);
        }
    }

    public void ShowSpinnerFinished()
    {
        //Console.WriteLine();
        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            switch (counter % 4)
            {
                case 0: Console.Write("\rWell done!!! /"); break;
                case 1: Console.Write("\rWell done!!! -"); break;
                case 2: Console.Write("\rWell done!!! \\"); break;
                case 3: Console.Write("\rWell done!!! |"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 14, Console.CursorTop);
            counter++;
            Thread.Sleep(75);
        }
    }

}