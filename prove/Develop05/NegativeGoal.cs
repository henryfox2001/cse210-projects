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
    // Methods
    public override void ListGoal(int i)
    {
        Console.WriteLine($"{i}. [ ] {GetName()} ({GetDescription()})");
    }
    public override string SaveGoal()
    {
        return ($"{_type}| {GetName()}| {GetDescription()}| {GetPoints()}| {_status}");
    }
    public override string LoadGoal()
    {
        return ($"{_type}| {GetName()}| {GetDescription()}| {GetPoints()}| {_status}");
    }
    public override int RecordGoalEvent(List<Goal> goals)
    {
        Console.WriteLine($"I'm sorry! You have Lost {GetPoints()} points!");
        return _points * -1;
    }

}