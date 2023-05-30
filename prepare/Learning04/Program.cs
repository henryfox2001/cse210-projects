using System;

class Program
{
    static void Main(string[] args)
    {

        Assignment assig1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assig1.GetSummary());

        MathAssignment assig2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assig2.GetSummary());
        Console.WriteLine(assig2.GetHomeworkList());

        WritingAssignment assig3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(assig3.GetSummary());
        Console.WriteLine(assig3.GetWritingInformation());

    }
}