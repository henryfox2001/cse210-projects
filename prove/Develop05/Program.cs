using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Use to convert text to title case
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        QuestProgram goals = new QuestProgram();

        Console.Clear();  // This will clear the console
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n->->-> Welcome to the Eternal Quest Program <-<-<-\n");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"\n->->->->-> You currently have {goals.GetTotalPoints()} points! <-<-<-<-<-\n");
        Console.ResetColor();

        //Call MainMenu
        MainMenu choice = new MainMenu();

        //Call GoalMenu
        GoalMenu goalChoice = new GoalMenu();

        int action = 0;
        while (action != 6)
        // switch case for main menu
        {
            // Ask for user input
            action = choice.UserChoice();
            switch (action)
            {
                case 1: // Create New Goal
                    Console.Clear(); // This will clear the console
                    // Ask for user input
                    int goalInput = 0;
                    while (goalInput != 5)
                    // switch case for goals menu
                    {
                        goalInput = goalChoice.GoalChoice();
                        switch (goalInput)
                        {
                            case 1: // Simple Goal
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("\nWhat is the name of your goal? ");
                                string name = Console.ReadLine();
                                Console.ResetColor();
                                name = textInfo.ToTitleCase(name);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is a short description of your goal? ");
                                string description = Console.ReadLine();
                                Console.ResetColor();
                                description = textInfo.ToTitleCase(description);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is the amount of points associated with this goal? ");
                                int points = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                SimpleGoal sGoal = new SimpleGoal("Simple Goal:", name, description, points);
                                goals.AddGoal(sGoal);
                                goalInput = 5;
                                Console.Clear(); // This will clear the console
                                break;
                            case 2: // Eternal Goal
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is the name of your goal? ");
                                name = Console.ReadLine();
                                Console.ResetColor();
                                name = textInfo.ToTitleCase(name);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is a short description of your goal? ");
                                description = Console.ReadLine();
                                Console.ResetColor();
                                description = textInfo.ToTitleCase(description);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is the amount of points associated with this goal? ");
                                points = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                EternalGoal eGoal = new EternalGoal("Eternal Goal:", name, description, points);
                                Console.ResetColor();
                                goals.AddGoal(eGoal);
                                goalInput = 5;
                                Console.Clear(); // This will clear the console
                                break;
                            case 3: // Checklist Goal
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("\nWhat is the name of your goal? ");
                                name = Console.ReadLine();
                                Console.ResetColor();
                                name = textInfo.ToTitleCase(name);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is a short description of your goal? ");
                                description = Console.ReadLine();
                                Console.ResetColor();
                                description = textInfo.ToTitleCase(description);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is the amount of points associated with this goal? ");
                                points = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                                int numberTimes = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is the bonus for accomplishing it that many times? ");
                                int bonusPoints = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                ChecklistGoal clGoal = new ChecklistGoal("Check List Goal:", name, description, points, numberTimes, bonusPoints);
                                Console.ResetColor();
                                goals.AddGoal(clGoal);
                                goalInput = 5;
                                Console.Clear(); // This will clear the console
                                break;
                            case 4: // Negative Goal
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is the name of your goal? ");
                                name = Console.ReadLine();
                                Console.ResetColor();
                                name = textInfo.ToTitleCase(name);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("What is a short description of your goal? ");
                                description = Console.ReadLine();
                                Console.ResetColor();
                                description = textInfo.ToTitleCase(description);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("How many points should be subtracted for not meeting this goal? ");
                                points = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                NegativeGoal nGoal = new NegativeGoal("Negative Goal:", name, description, points);
                                Console.ResetColor();
                                goals.AddGoal(nGoal);
                                goalInput = 5;
                                Console.Clear(); // This will clear the console
                                break;
                            case 5: // Exit
                                Console.Clear();  // This will clear the console
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nSorry the option you entered is not valid.");
                                Console.ResetColor();
                                break;
                        }
                    }
                    break;
                case 2: // List Goals
                    Console.Clear();  // This will clear the console
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n->->-> You currently have {goals.GetTotalPoints()} points! <-<-<-\n");
                    Console.ResetColor();
                    goals.ListGoals();
                    break;
                case 3: // Save Goals
                    goals.SaveGoals();
                    Console.Clear();  // This will clear the console
                    break;
                case 4: // Load Goals
                    Console.Clear();  // This will clear the console
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n->->-> You currently have {goals.GetTotalPoints()} points! <-<-<-\n");
                    Console.ResetColor();
                    goals.LoadGoals();
                    break;
                case 5: // Record Event
                    Console.Clear();  // This will clear the console
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n->->-> You currently have {goals.GetTotalPoints()} points! <-<-<-\n");
                    Console.ResetColor();
                    goals.RecordGoalEvent();
                    Console.Clear();  // This will clear the console
                    break;
                case 6: // Quite
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThank you for using the Eternal Quest Program!\n");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry the option you entered is not valid.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();  // This will clear the console
                    break;
            }
        }
    }
}