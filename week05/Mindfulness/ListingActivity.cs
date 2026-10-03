using System;

class ListingActivity : Activity
{
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
        
        GetRandomPrompt();
        ShowSpinner();
        
        CountDown();

        GetListFromUser(duration);
        ShowSpinner();
        
        DisplayEndingMessage(name, duration);
        ShowSpinner();

        Console.Clear();

        Activity.IncrementActivityCount();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine("List as many responses you can to the following prompt:");
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