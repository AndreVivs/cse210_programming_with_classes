using System;

public class Running : Workout
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base(minutes, date)
        {
            _distance = distance;
        }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
            return 0;
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        if (GetDistance() == 0)
            return 0;
        return GetMinutes() / GetDistance();
    }
}