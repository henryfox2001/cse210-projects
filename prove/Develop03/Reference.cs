using System;

// A code template for the category of things known as 
public class Reference
{
    // Variables
    public List<Reference> _reference = new List<Reference>();
    private string _fileName = "ScriptureFile.txt";
    private string _key;
    private string _nameBook;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference()
    {
    }

    // Methods
    public void LoadReference()
    {
        List<string> readText = File.ReadAllLines(_fileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

        foreach (string line in readText)
        {
            string[] entries = line.Split(";");

            Reference entry = new Reference();

            entry._key = entries[0];
            entry._nameBook = entries[1];
            entry._chapter = int.Parse(entries[2]);
            entry._verseStart = int.Parse(entries[3]);
            entry._verseEnd = int.Parse(entries[4]);

            _reference.Add(entry);
        }
    }

    public string GetReference(Scripture scripture)
    {
        var index = scripture._index;
        var referIndex = _reference[index];
        string refer1;

        if (referIndex._verseEnd.Equals(0))
        {
            return refer1 = ($"\n{referIndex._nameBook} {referIndex._chapter}:{referIndex._verseStart}");
        }
        else
        {
            return refer1 = $"\n{referIndex._nameBook} {referIndex._chapter}:{referIndex._verseStart}-{referIndex._verseEnd}";
        }
    }
}