using System;
using System.Collections.Generic;

public class NegativeGoal : Goal
{
    // Attributes
    private bool _status;

    // Constructors
    public NegativeGoal(string type, string name, string description, int points) : base(type, name, description, points)
    {
        _status = false;
        _type = "Negative Goal:";
    }
    public NegativeGoal(string type, string name, string description, int points, bool status) : base(type, name, description, points)
    {
        _status = status;
        _type = "Negative Goal:";
    }
    public Boolean Finished()
    {
        return _status;
    }

    // Methods
    public override void ListGoal(int i)
    {
        Console.WriteLine($"{i}. [ ] {GetName()} ({GetDescription()})");
    }
    public override string SaveGoal()
    {
        return ($"{_type}| {GetName()}| {GetDescription()}| {GetPoints()}| {Finished()}");
    }
    public override int RecordGoalEvent(List<Goal> goals)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"I'm sorry! You have Lost {GetPoints()} points!");
        Console.ResetColor();
        return _points * -1;
    }

}