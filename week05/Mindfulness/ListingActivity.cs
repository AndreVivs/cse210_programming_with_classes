using System;

class ListingActivity : Activity
{
    private Random _random = new Random();
    private List<string> _availablePrompts;
    private List<string>_prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void Run(string name, string description)
    {
        int duration = DisplayStartingMessage(name, description);

        Console.WriteLine("Get Ready...");
        ShowSpinner();

        DisplayPrompt();
        ShowSpinner();

        CountDown();

        GetListFromUser(duration);
        ShowSpinner();

        DisplayEndingMessage(name, duration);
        ShowSpinner();

        Activity.IncrementActivityCount();

        Console.Clear();
    }

     public ListingActivity()
    {
        _availablePrompts = new List<string>(_prompts);
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_availablePrompts.Count);

        string prompt = _availablePrompts[index];

        _availablePrompts.RemoveAt(index);

        return prompt;
    }


    public void DisplayPrompt()
    {
        if (_availablePrompts.Count == 0)
        {
            _availablePrompts.AddRange(_prompts);
        }

        string prompt = GetRandomPrompt();

        Console.WriteLine(
            "List as many responses as you can to the following prompt:"
        );

        Console.WriteLine();

        Console.WriteLine($"---{prompt}---");

        Console.WriteLine();
    }

    public void GetListFromUser(int duration)
    {
        List<string> list = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime || list.Count == 0)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                list.Add(input);
            }
            else
            {
                Console.WriteLine("Your answer cannot be empty. Please enter an item.");
            }
        }

        Console.WriteLine($"You have listed {list.Count} items.");
    }
}