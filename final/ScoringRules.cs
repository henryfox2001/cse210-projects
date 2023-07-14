using System;

public abstract class ScoringRules
{
    // Attributes
    protected int score;
    protected int len;
    
    // Methods
    public abstract int CalculateScore(int numGuesses, List<string> letters, string word);

    public abstract void ShowScore();
}
