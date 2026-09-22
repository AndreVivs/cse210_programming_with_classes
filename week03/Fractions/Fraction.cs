
class Fraction
{
    private int _topNumerator;
    private int _bottomDenominator;

    public Fraction()
    {
        _topNumerator = 1;
        _bottomDenominator = 1;
    }

    public Fraction(int topNumerator)
    {
        _topNumerator = topNumerator;
        _bottomDenominator = 1;
    }

    public Fraction(int topNumerator, int bottomDenominator)
    {
        _topNumerator = topNumerator;
        _bottomDenominator = bottomDenominator;
    }

    public void Display()
    {
        Console.WriteLine($"{_topNumerator}/{_bottomDenominator}");
    }

    public int GetTopNumerator()
    {
        return _topNumerator;
    }
     public int GetBottomDenominator()
    {
        return _bottomDenominator;
    }


    public void SetTopNumerator(int topNumerator)
    {
        _topNumerator = topNumerator;
    }

    public void SetBottomDenominator(int bottomDenominator)
    {
        _bottomDenominator = bottomDenominator;
    }
    public string GetFractionString()
    {
        return $"{_topNumerator}/{_bottomDenominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_topNumerator / _bottomDenominator;
    }
}