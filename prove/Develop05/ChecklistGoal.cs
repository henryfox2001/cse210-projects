using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    // Attributes
    private int _numberTimes;
    protected int _bonusPoints;
    private bool _status;
    private int _count;

    // Constructors
    public ChecklistGoal(string type, string name, string description, int points, int numberTimes, int bonusPoints) : base(type, name, description, points)
    {
        _status = false;
        _numberTimes = numberTimes;
        _bonusPoints = bonusPoints;
        _count = 0;
        _type = "Check List Goal:";
    }
    public ChecklistGoal(string type, string name, string description, int points, bool status, int numberTimes, int bonusPoints, int count) : base(type, name, description, points)
    {
        _status = status;
        _numberTimes = numberTimes;
        _bonusPoints = bonusPoints;
        _count = count;
        _type = "Check List Goal:";
    }

    public int GetTimes()
    {
        return _numberTimes;
    }
    public void SetTimes()
    {
        _count = _count + 1;
    }
     public int GetCount()
    {
        return _count;
    }
     public int GetBonusPoints()
    {
        return _bonusPoints;
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
            Console.WriteLine($"{i}. [ ] {GetName()} ({GetDescription()})  -->  Currently Completed: {GetCount()}/{GetTimes()}");
        }
        else if (Finished() == true)
        {
            Console.WriteLine($"{i}. [X] {GetName()} ({GetDescription()})  -->  Completed: {GetCount()}/{GetTimes()}");
        }

    }
    public override string SaveGoal()
    {
        return ($"{_type}| {GetName()}| {GetDescription()}| {GetPoints()}| {_status}| {GetTimes()}| {GetBonusPoints()}| {GetCount()}");
    }
    public override string LoadGoal()
    {
        return ($"Check List Goal:| {GetName()}| {GetDescription()}| {GetPoints()}| {_status}| {GetTimes()}| {GetBonusPoints()}| {GetCount()}");
    }

    public override int RecordGoalEvent(List<Goal> goals)
    {
        SetTimes();
        if (_count == _numberTimes)
        {
            _status = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nCongratulations! You have earned {GetPoints()} points!");
            Console.WriteLine($"Congratulations! You have earned {_bonusPoints} extra points!");
            Console.ResetColor();
            return _points + _bonusPoints;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nCongratulations! You have earned {GetPoints()} points!");
            Console.ResetColor();
            return _points;
        }
    }
    
}
