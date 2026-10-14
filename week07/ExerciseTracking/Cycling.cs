
using System;

public class Cycling : Workout
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(minutes, date)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (GetSpeed() * GetMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}