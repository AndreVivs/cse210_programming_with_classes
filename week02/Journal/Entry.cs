using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _userResponse;

    public Entry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();

        _date = DateTime.Now.ToString("MM/dd/yyyy");
        _promptText = promptGenerator.GeneratePrompt();
        _userResponse = "";
    }

    public Entry(string date, string promptText, string userResponse)
    {
        _date = date;
        _promptText = promptText;
        _userResponse = userResponse;
    }

    public void WriteEntry()
    {
        Console.WriteLine(_promptText);
        Console.Write("> ");
        _userResponse = Console.ReadLine() ?? "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_userResponse);
    }

    public bool HasResponse()
    {
        return !string.IsNullOrWhiteSpace(_userResponse);
    }

    public string GetFileString()
    {
        return $"{_date}|{_promptText}|{_userResponse}";
    }
}