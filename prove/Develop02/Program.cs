using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //int[] validNumbers = { 1, 2, 3, 4, 5 };
        int action = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\nWelcome to the Journal Program!  \n");
        Console.ResetColor();
        
        // Create new journal reference.
        Journal journal = new Journal();
        JournalPrompt jp = new JournalPrompt();

        // Ask for menu input.
        while (action != 5)
        {
            action = Choices();

            switch (action)
            {
                case 1: // Write Journal Entry.
                    string dateInfo = GetDateTime();
                    string prompt = jp.GetPrompt();

                    JournalEntry entry = new JournalEntry();
                    entry._dateTime = dateInfo;
                    entry._journalPrompt = prompt;

                    Console.Write($"{prompt}\n");
                    Console.Write("--> ");
                    string userEntry = Console.ReadLine();
                    entry._journalEntry = userEntry;
                    Console.Clear();
                    journal._journal.Add(entry);

                    break;
                case 2: // Display Journal Entries.
                    journal.Display();
                    break;
                case 3: // Load text file.
                    journal.LoadJournalFile();
                    break;
                case 4: // Save to text file.
                    journal.CreateJournalFile();
                    break;
                case 5: // Quite
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nThank you for using the Journal Program!\n");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry the option you entered is not valid!");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static int Choices()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nPlease select one of the following choices:\n");
        Console.ResetColor();
        Console.Write("1. Write\n");
        Console.Write("2. Display\n");
        Console.Write("3. Load\n");
        Console.Write("4. Save\n");
        Console.Write("5. Quit\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nWhat would you like to do? ");
        Console.ResetColor();

        string choices = @"";

        Console.Write(choices);
        string userInput = Console.ReadLine();
        Console.Clear();
        int action = 0;
        // It catches any non integer values that are entered.
        try
        {
            action = int.Parse(userInput);
        }
        catch (FormatException)
        {
            action = 0;
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Unexpected error:  {exception.Message}");
            Console.ResetColor();
        }
        return action;
    }

    static string GetDateTime()
    // Getting the date and time for journal record.
    {
        DateTime now = DateTime.Now;
        string currentDateTime = now.ToString("F");
        return currentDateTime;
    }
    static void AddJournalEntry()
    // Add entry to text file.
    {
        string MyJournalFile = "MyJournal.txt";
        File.AppendAllText(MyJournalFile, "");
    }
}