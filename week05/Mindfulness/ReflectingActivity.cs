using System;

// The number of questions displayed to the user depend on the duration of the session.
// Any questions that have already been asked will not be repeated.
// More prompts and questions were added

class ReflectingActivity : Activity
{
    private Random _random = new Random();
    private List<string> _availablePrompts;
    
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

    public ReflectingActivity()
    {
        _availablePrompts = new List<string>(_prompts);
    }


    public void Run(string name, string description)
    {
        List<string> availablePrompts = new List<string>(_prompts);

        List<string> availableQuestions = new List<string>(_questions);

        int duration =
            DisplayStartingMessage(name, description);

        Console.WriteLine("Get Ready...");
        ShowSpinner();

        string enter =
            DisplayPrompt(availablePrompts);

        if (enter == "")
        {
            Console.WriteLine(
                "Now ponder on each of the following questions as they relate to this experience."
            );

            CountDown();

            Console.Clear();

            DisplayQuestion(
                duration,
                availableQuestions
            );
        }

        ShowSpinner();

        DisplayEndingMessage(
            name,
            duration
        );

        ShowSpinner();

        Activity.IncrementActivityCount();
        
        Console.Clear();
    }

    public string GetRandomPrompt()
    {
        return GetRandomPrompt(_availablePrompts);
    }

    public string GetRandomPrompt(List<string> availablePrompts)
    {
        if (availablePrompts.Count == 0)
        {
            availablePrompts = new List<string>(_prompts);
        }

        int index = _random.Next(availablePrompts.Count);

        string prompt = availablePrompts[index];

        availablePrompts.RemoveAt(index);

        return prompt;
    }

    public string GetRandomQuestion(List<string> availableQuestions)
    {
        int index = _random.Next(availableQuestions.Count);

        string question = availableQuestions[index];

        availableQuestions.RemoveAt(index);

        return question;
    }

    public string DisplayPrompt(List<string> availablePrompts)
    {
        string prompt = GetRandomPrompt(availablePrompts);

        Console.WriteLine("Consider the following prompt.");
        Console.WriteLine();
        Console.WriteLine($"---{prompt}---");
        Console.WriteLine();

        Console.Write(
            "When you have something in mind, press Enter to continue:"
        );

        string enter = Console.ReadLine();

        Console.WriteLine();

        return enter;
    }

    public void DisplayQuestion(int duration, List<string> availableQuestions)
    {
        int questionDuration = 5;
        int questionCount = duration / questionDuration;

        while (questionCount > 0)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions =
                    new List<string>(_questions);
            }

            string question =
                GetRandomQuestion(availableQuestions);

            Console.Write(question);

            ShowSpinner(questionDuration);

            questionCount--;
        }

        Console.WriteLine();
        Console.WriteLine("Well done! - Session completed.");
    }
}