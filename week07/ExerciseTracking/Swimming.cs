
using System;

public class Swimming : Workout
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(minutes, date)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50.0) / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
