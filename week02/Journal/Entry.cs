using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();

        _date = DateTime.Now.ToString("MM/dd/yyyy");
        _promptText = promptGenerator.GeneratePrompt();
        _entryText = "";
    }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void WriteEntry()
    {
        Console.WriteLine(_promptText);
        Console.Write("> ");

        _entryText = Console.ReadLine() ?? "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
    }

    public bool HasResponse()
    {
        return !string.IsNullOrWhiteSpace(_entryText);
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPromptText()
    {
        return _promptText;
    }

    public string GetEntryText()
    {
        return _entryText;
    }
}