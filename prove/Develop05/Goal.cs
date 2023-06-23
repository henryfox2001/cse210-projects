using System;
using System.Collections.Generic;

public abstract class Goal
{
    // Attributes
    protected string _type;
    private string _name;
    private string _description;
    protected int _points;

    // Constructors
    public Goal(string type, string name, string description, int points)
    {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetPoints()
    {
        return _points;
    }

    // Methods
    public abstract void ListGoal(int i);
    public abstract string SaveGoal();
    public abstract string LoadGoal();
    public abstract int RecordGoalEvent(List<Goal> goals);

}