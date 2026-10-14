using System;

public abstract class Workout
{
    private int _minutes;
    private DateTime _date;

    public Workout(int minutes, DateTime date)
    {
        _minutes = minutes;
        _date = date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():F2} km, " +
               $"Speed: {GetSpeed():F2} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }
}