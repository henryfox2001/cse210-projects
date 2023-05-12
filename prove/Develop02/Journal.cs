using System;
using System.IO;

public class Journal
{
    // Variables.
    public List<JournalEntry> _journal = new List<JournalEntry>();

    private string _userFileName;

    public Journal()
    {
    }

    // Display each journal entry.
    public void Display()
    {
        Console.WriteLine("\n->->->->->-> Journal Entries <-<-<-<-<-<-");
        foreach (JournalEntry journalEntry in _journal)
        {
            journalEntry.Display();
        }
        Console.WriteLine("->->->->->-> End <-<-<-<-<-<-");
    }

    // Creates a file.txt
    public void CreateJournalFile()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter file name? ");
        Console.ResetColor();
        string userInput = Console.ReadLine();
        _userFileName = userInput + ".txt";

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"\n->->->-> {_userFileName} has been created! <-<-<-<-\n");
        Console.Write("->->->  Your journal entries have been saved. <-<-<-\n");
        Console.ResetColor();
        SaveJournalFile(_userFileName);
    }

    // Saves the journal to .txt file.
    public void SaveJournalFile(string _userFileName)
    { 
        using (StreamWriter outputFile = new StreamWriter(_userFileName))
        {
            foreach (JournalEntry journalEntry in _journal)
            {
                outputFile.WriteLine($"{journalEntry._dateTime}; {journalEntry._journalPrompt}; {journalEntry._journalEntry}");
            }
        }
    }

    // Check if the .txt file exists and load the list.
    public void LoadJournalFile()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("What is your file name? ");
        Console.ResetColor();
        string userInput = Console.ReadLine();
        _userFileName = userInput + ".txt";

        if (File.Exists(_userFileName))
        {
            List<string> readText = File.ReadAllLines(_userFileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            foreach (string line in readText)
            {
                string[] entries = line.Split(";");

                JournalEntry entry = new JournalEntry();

                entry._dateTime = entries[0];
                entry._journalPrompt = entries[1];
                entry._journalEntry = entries[2];

                _journal.Add(entry);
            }
        }
    }
}