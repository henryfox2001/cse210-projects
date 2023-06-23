using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    // Attributes
    private bool _status;

    // Constructors
    public EternalGoal(string type, string name, string description, int points) : base(type, name, description, points)
    {
        _status = false;
        _type = "Eternal Goal:";
    }
    public EternalGoal(string type, string name, string description, int points, bool status) : base(type, name, description, points)
    {
        _status = status;
        _type = "Eternal Goal:";
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
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");
        Console.ResetColor();
        return _points;
    }

}