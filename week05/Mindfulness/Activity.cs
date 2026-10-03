using System;

class Activity
{
    private string _name;
    private string _description;
    private int _duration = 3;

    public string DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        Console.Write("Select an option from the menu: ");
        _name = Console.ReadLine();
        
        Console.Clear();

        return _name;
    }
        public int DisplayStartingMessage(string name, string description)
    {
        Console.WriteLine($"Welcome to the {name}.");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());

        Console.Clear();

        return duration;
    }

    public void DisplayEndingMessage(string name, int duration)
    {
        Console.WriteLine($"You have completed {duration} seconds of the {name}.");
    }

    public void ShowSpinner()
        {
            ShowSpinner(_duration);
        }

    public void ShowSpinner(int duration)
    {
        List<string> animation = new List<string>
        {
            "|", "/", "-", "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[i]);
            Thread.Sleep(250);
            Console.Write("\b");

            i++;

            if (i >= animation.Count)
            {
                i = 0;
            }
        }

        Console.Write(" ");
        Console.Write("\b");

        Console.WriteLine();
    }

    public void ShowCountDown(int duration)
    {
        int breathDuration = 10;
        int breaths = duration / breathDuration;

        for (int b = 0; b < breaths; b++)
        {
            for (int breathIn = 4; breathIn > 0; breathIn--)
            {
                Console.Write($"\rBreathe in...{breathIn} ");
                Thread.Sleep(1000);
            }

            Console.Write("\rBreathe in...   ");
            Console.WriteLine();

            for (int breathOut = 6; breathOut > 0; breathOut--)
            {
                Console.Write($"\rNow breathe out...{breathOut} ");
                Thread.Sleep(1000);
            }

            Console.Write("\rNow breathe out...   ");
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine("Well done! - Session completed.");
    }

    public int CountDown()
    {
        int count = 5;
        while (count > 0)
        {
            Console.Write($"\rYou may begin in: {count} ");
            Thread.Sleep(1000);
            count--;
        }
        Console.WriteLine();
        return count;
    }
    public List<object> GetBaseClassData()
    {
        if (_name == "1")
        {
            _name = "Breathing Activity";
            _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
        else if (_name == "2")
        {
            _name = "Reflecting Activity";
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }
        else if (_name == "3")
        {
            _name = "Listing Activity";
            _description = "This activity will help you list and organize your thoughts, enhancing clarity and focus.";
        }
        else if (_name == "4")
        {
            _name = "Quit";
        }
        return new List<object> { _name, _description, };
    }
}