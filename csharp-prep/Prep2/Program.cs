using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade in %? ");
        string yourGrade = Console.ReadLine();
        int percentage = int.Parse(yourGrade);

        string letterGrade = "";

        if (percentage >= 90)
        {
            letterGrade = "A";
        }
        else if (percentage >= 80)
        {
            letterGrade = "B";
        }
        else if (percentage >= 70)
        {
            letterGrade = "C";
        }
        else if (percentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        /*
        // Core Requirements
        Console.WriteLine($"Your grade is: {letterGrade}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("It wasn't at this time. Don't be dicouraged!");
        }
        */

        // Stretch Challenge
        int lastDigit;
        string symbol;
        symbol = "";

        lastDigit = percentage % 10;

        if (lastDigit >= 7)
        {
            symbol = "+";
        }
        else if (lastDigit < 3)
        {
            symbol = "-";
        }
        else
        {
            symbol = "";
        }

        if (percentage >= 93)
        {
            symbol = "";
        }

        if (letterGrade == "A")
        {
            if (symbol == "+")
            {
                symbol = "";
            }
        }
        else if (letterGrade == "F")
        {
            symbol = "";
        }

        Console.WriteLine($"Your grade is: {letterGrade}{symbol}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulation, you pass!");
        }
        else
        {
            Console.WriteLine("It wasn't at this time. Don't be dicouraged!");
        }
    }
}