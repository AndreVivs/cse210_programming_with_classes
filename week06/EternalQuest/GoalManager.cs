
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int type)
            || type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("How many points is this goal worth? ");

        if (!int.TryParse(Console.ReadLine(), out int points)
            || points <= 0)
        {
            Console.WriteLine("Points must be a positive number.");
            return;
        }

        Goal goal;

        if (type == 1)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == 2)
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            Console.Write("How many times must this goal be completed? ");

            if (!int.TryParse(Console.ReadLine(), out int target)
                || target <= 0)
            {
                Console.WriteLine("Target must be a positive number.");
                return;
            }

            Console.Write("What is the bonus for completing the goal? ");

            if (!int.TryParse(Console.ReadLine(), out int bonus)
                || bonus < 0)
            {
                Console.WriteLine("Bonus cannot be negative.");
                return;
            }

            goal = new ChecklistGoal(
                name, description, points, target, bonus
            );
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}"
            );
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first!");
            return;
        }

        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice)
            || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points!"
        );

        DisplayPlayerInfo();
    }


    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine() ?? "";

        string projectDirectory = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..")
        );

        string filename = Path.Combine(projectDirectory, Path.GetFileName(fileName));

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Please enter a valid filename.");
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
            Console.WriteLine($"File location: {Path.GetFullPath(filename)}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access denied: {ex.Message}");
        }
    }

    
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine() ?? "";

        string projectDirectory = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..")
        );

        string filename = Path.Combine(projectDirectory, Path.GetFileName(fileName));
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal goal;

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal simpleGoal =
                        new SimpleGoal(name, description, points);

                    simpleGoal.SetComplete(isComplete);
                    goal = simpleGoal;
                }
                else if (goalType == "EternalGoal")
                {
                    goal = new EternalGoal(name, description, points);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    ChecklistGoal checklistGoal =
                        new ChecklistGoal(
                            name, description, points, target, bonus
                        );

                    checklistGoal.SetAmountCompleted(amountCompleted);
                    goal = checklistGoal;
                }
                else
                {
                    throw new FormatException("Unknown goal type.");
                }

                loadedGoals.Add(goal);
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is FormatException ||
            ex is IndexOutOfRangeException ||
            ex is OverflowException ||
            ex is ArgumentException
        )
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
