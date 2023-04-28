using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int counter = 0;
        int number = -1;
        int tracker = -1;
        int smaller = 0;
        //float average = 0;

        while (number != 0)
        {
            Console.Write("Enter number: ");

            string userResponse = Console.ReadLine();
            number = int.Parse(userResponse);

            if (number != 0)
            {
                numbers.Add(number);
                counter += number;
            }

            if (number > 0 && smaller == 0)
            {
                smaller = number;
            }

            else if (number > 0 && number < smaller)
            {
                smaller = number;
            }

            if (number > tracker)
            {
                tracker = number;
            }
        }
        Console.WriteLine($"The sum is {counter}");

        if (numbers.Count == 0)
        {
            Console.WriteLine("The average is zero");
        }
        else
        {
            //float average = ((float)counter) / numbers.Count;
            Console.WriteLine($"The average is: {((float)counter) / numbers.Count}");
        }
        Console.WriteLine($"The largest number is: {tracker}");
        Console.WriteLine($"The smallest positive number is: {smaller}");
        numbers.Sort();

        for (int i = 0; i < numbers.Count; i++)
        {
            int numb = numbers[i];
            Console.WriteLine(numb);
        }
    }
}