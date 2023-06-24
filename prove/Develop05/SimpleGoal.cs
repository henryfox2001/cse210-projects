using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    // Attributes
    private bool _status;

    // Constructors
    public SimpleGoal(string type, string name, string description, int points) : base(type, name, description, points)
    {
        _status = false;
        _type = "Simple Goal:";
    }
    public SimpleGoal(string type, string name, string description, int points, bool status) : base(type, name, description, points)
    {
        _status = status;
        _type = "Simple Goal:";
    }
    public Boolean Finished()
    {
        return _status;
    }

    // Methods
    public override void ListGoal(int i)
    {
        if (Finished() == false)
        {
            Console.WriteLine($"{i}. [ ] {GetName()} ({GetDescription()})");
        }
        else if (Finished() == true)
        {
            Console.WriteLine($"{i}. [X] {GetName()} ({GetDescription()})");
        }
    }
    public override string SaveGoal()
    {
        return ($"{_type}| {GetName()}| {GetDescription()}| {GetPoints()}| {Finished()}");
    }
    public override int RecordGoalEvent(List<Goal> goals)
    {
       _status = true;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nCongratulations! You have earned {GetPoints()} points!");
        Console.ResetColor();
        return _points;
    }

}