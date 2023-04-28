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

























        /*
        List<int> numbers = new List<int>();
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Compute the average
        // Notice that we first cast the sum variable to be a float. Otherwise, because
        // both the sum and the count are integers, the computer will do integer division
        // and I will not get a decimal value (even though it puts the result into a float variable).

        // By making one of the variables a float first, the computer knows that it has to
        // do the floating point division, and we get the decimal value that we expect.
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Part 3: Find the max
        // There are several ways to do this, such as sorting the list
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                // if this number is greater than the max, we have found the new max!
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}
*/