using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirements #1
        /*
        int guess = 0;
        int magicNumber = 0;

        Console.Write("What is the magic number? ");
            magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        */

        // Core Requirements #2, #3, and Stretch Challenge 
        string response = "yes";

        while (response == "yes" || response =="y" || response == "YES" || response == "Y")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int track = 1;
            int guessNumber = -1;

            while (guessNumber != magicNumber)
            {
                Console.Write("What is your guess? ");
                guessNumber = int.Parse(Console.ReadLine());

                if (magicNumber > guessNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guessNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You guessed {track} times!");
                }
                track = track +1;
            }
            Console.Write("Want to play again [yes/no]? ");
            response = Console.ReadLine();            
        }
    }
}