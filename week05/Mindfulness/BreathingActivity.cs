using System;

class BreathingActivity : Activity
{
    public void Run(string name, string description)
    {
        int duration = DisplayStartingMessage(name, description);
        Console.WriteLine("Get Ready...");
        ShowSpinner();
        ShowCountDown(duration);
        ShowSpinner();
        DisplayEndingMessage(name,duration);
        ShowSpinner();

        Console.Clear();

        DisplayMenu();
    }
}