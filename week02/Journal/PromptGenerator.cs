using System;

public class PromptGenerator
{
    public string GeneratePrompt()
    {
        string[] prompts =
        {
            "What are you grateful for today?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "Describe a challenge you faced and how you overcame it.",
            "What is a goal you want to achieve this week?",
            "Reflect on a recent accomplishment and how it made you feel.",
            "Write about a person who has had a positive impact on your life."
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);

        return prompts[index];
    }
}