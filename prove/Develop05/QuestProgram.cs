using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

public class QuestProgram
{
    // Attributes
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints;

    // Constructors
    public QuestProgram()
    {
        _totalPoints = 0;
    }
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public int GetTotalPoints()
    {
        return _totalPoints;
    }
    public void AddPoints(int points)
    {
        _totalPoints += points;
    }
    public void SetTotalPoints(int totalPoints)
    {
        _totalPoints = totalPoints;
    }
    public List<Goal> GetGoalsList()
    {
        return _goals;
    }

    // Methods
    public void ListGoals()
    {
        if (_goals.Count() > 0)
        {
            Console.WriteLine("\nYour Goals are:");

            int index = 1;
            // Loop though goals list
            foreach (Goal goal in _goals)
            {
                goal.ListGoal(index);
                index = index + 1;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou currently have no goals!");
            Console.ResetColor();
            Thread.Sleep(3000);
            Console.Clear(); // This will clear the console
        }
    }

    public void RecordGoalEvent()
    {
        ListGoals();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("\nWhich goal did you accomplished?  ");
        int select = int.Parse(Console.ReadLine()) - 1;
        Console.ResetColor();

        AddPoints(GetGoalsList()[select].RecordGoalEvent(_goals));

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n->->-> You have {GetTotalPoints()} points! <-<-<-\n");
        Console.ResetColor();
        Thread.Sleep(3000);
        Console.Clear(); // This will clear the console
    }

    public void SaveGoals()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nWhat is the name for this goal file?  ");
        string userInput = Console.ReadLine();
        Console.ResetColor();
        string userFileName = userInput + ".txt";

        using (StreamWriter outputFile = new StreamWriter(userFileName))
        {
            // Save Total Points
            outputFile.WriteLine(GetTotalPoints());
            // Save goals list
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.SaveGoal());
            }
        }
    }

    public void LoadGoals()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nWhat is the name of your goal file? ");
        string userInput = Console.ReadLine();
        Console.ResetColor();
        string userFileName = userInput + ".txt";

        if (File.Exists(userFileName))
        {
            string[] readText = File.ReadAllLines(userFileName);

            // read the first line of text file for total stored points
            int totalPoints = int.Parse(readText[0]);
            SetTotalPoints(totalPoints);
            // skip the first line of text file to read to goals
            readText = readText.Skip(1).ToArray();
            // loop though text file for goals
            foreach (string line in readText)
            {
                string[] entries = line.Split("| ");

                string type = entries[0];
                string name = entries[1];
                string description = entries[2];
                int points = int.Parse(entries[3]);
                bool status = Convert.ToBoolean(entries[4]);

                if (entries[0] == "Simple Goal:")
                {
                    SimpleGoal simpleGoal = new SimpleGoal(type, name, description, points, status);
                    AddGoal(simpleGoal);
                }
                if (entries[0] == "Eternal Goal:")
                {
                    EternalGoal eternalGoal = new EternalGoal(type, name, description, points, status);
                    AddGoal(eternalGoal);
                }
                if (entries[0] == "Check List Goal:")
                {
                    int numberTimes = int.Parse(entries[5]);
                    int bonusPoints = int.Parse(entries[6]);
                    int counter = int.Parse(entries[7]);
                    ChecklistGoal clistGoal = new ChecklistGoal(type, name, description, points, status, numberTimes, bonusPoints, counter);
                    AddGoal(clistGoal);
                }
                if (entries[0] == "Negative Goal:")
                {
                    NegativeGoal negativeGoal = new NegativeGoal(type, name, description, points, status);
                    AddGoal(negativeGoal);
                }
            }
        }
    }

}