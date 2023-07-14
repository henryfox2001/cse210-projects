using System;

public class ScoreSimple : ScoringRules
{
    // Attributes

    // Constructors

    // Methods
    public override int CalculateScore(int numGuesses, List<string> letters, string word)
    {
        score = numGuesses;
        return score;
    }
    public override void ShowScore()
    {
        Console.WriteLine($"Your simple word score: {score} ");
    }
}
