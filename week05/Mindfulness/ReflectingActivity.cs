using System;

// The number of questions displayed to the user depend on the duration of the session.
// and any questions that have already been asked will not be repeated.

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think about a time when you felt proud of yourself.",
        "Reflect on a challenge you overcame recently.",
        "Consider a moment when you showed kindness to others."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "How did this moment impact your life?",
        "What strengths did you demonstrate?"
    };


    public void Run(string name, string description)
    {
        int duration = DisplayStartingMessage(name, description);
        Console.WriteLine("Get Ready...");
        ShowSpinner();
        string enter = DisplayPrompt();

        if (enter == "")
        {
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            CountDown();
            Console.Clear();

            DisplayQuestion(duration);
        }
        ShowSpinner();
        DisplayEndingMessage(name,duration);
        ShowSpinner();

        Console.Clear();

        DisplayMenu();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];

    }
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public string DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt.");
        Console.WriteLine();
        Console.WriteLine($"---{prompt}---");
        Console.WriteLine();
        Console.Write("When you have something in mind, press Enter to continue:");
        string enter = Console.ReadLine();

        Console.WriteLine();

        return enter;
    }

    public void DisplayQuestion(int duration)
    {   
        int questionDuration = 5;
        int questionCount = duration / questionDuration;
        List<string> questionUsed = new List<string>();
        string question = GetRandomQuestion();
        
        while (questionCount > 0)
        {
            if (question != "" && !questionUsed.Contains(question))
            {
                questionUsed.Add(question);
                Console.Write(question);
                ShowSpinner(questionDuration);
                questionCount--;
            }
            question = GetRandomQuestion();
        }

        Console.WriteLine();
        Console.WriteLine("Well done! - Session completed.");

    }
}