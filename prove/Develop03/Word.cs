using System;

public class Word
{
    // Variables
    private string _word = "";
    private string _ref = "";
    public string[] _result;
    public List<int> _hidden;

    // Methods
    public Word()
    {
    }

    public void GetRenderedText(Scripture scripture)
    {
        var _word = scripture._scriptureText;
        _result = _word.Split(" ");
        _hidden = new List<int>();
    }

    public void GetRenderedRef(Scripture scripture)
    {
    }

    public void Show(string refer1)
    {
        _ref = refer1;
        Console.Clear(); // This will clear the console
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\n->->-> Press <Enter> to hide words <-<-<-");
        Console.Write("\n->->->->->-> Press Q to Quit <-<-<-<-<-<-\n");
        Console.ResetColor();
        Console.WriteLine($"{_ref}");

        for (var index = 0; index < _result.Length; index++)
        {
            if (_hidden.Contains(index))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(new string('_', _result[index].Length) + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{_result[index]} ");
            }

            // Check if all words are hidden
            if (_hidden.Count == _result.Length)
            {
                break;
            }
        }
    }

    public void GetReadKey()
    {
        var input = Console.ReadKey();

        if (input.Key == ConsoleKey.Enter)
        {
            GetNewHiddenWord();
        }
        else if (input.Key == ConsoleKey.Q)
        {
            Console.Clear(); // This will clear the console
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n->->-> Thanks for playing! <-<-<-\n");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }

    public void GetNewHiddenWord()
    {
        var random = new Random();
        var index1 = random.Next(_result.Length);
        var index2 = random.Next(_result.Length);
        
        if (_hidden.Contains(index1) || _hidden.Contains(index2))
        {
            GetNewHiddenWord();
        }
        else
        {
            _hidden.Add(index1);
            _hidden.Add(index2);
        }
    }
}