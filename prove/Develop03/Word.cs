using System;
using System.Linq;

// A code template for the category of things known as 
public class Word
{
    // Variables
    public string _words = "";
    public string _ref = "";
    public string[] _result;
    public List<int> _hidden;

    // Methods
    public Word()
    {
    }

    public Word(string text, string visible)
    {
    }

    public void GetRenderedText(Scripture scripture)
    {
        var _words = scripture._scriptureText;
        _result = _words.Split(" ");
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
        for (var i = 0; i < _result.Length; i++)
        {
            var str = _result[i];
            int len = str.Length;
            string dashedLine = new String('_', len);
            if (_hidden.Contains(i))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{dashedLine} ");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{str} ");
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