
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private int _currentStreak;
    private DateTime? _lastRecordedDate;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _currentStreak = 0;
        _lastRecordedDate = null;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_name} ({_description})";
    }
    
    // Streak-related methods
    public int GetCurrentStreak()
    {
        return _currentStreak;
    }

    public void UpdateStreak()
    {
        DateTime today = DateTime.Today;

        if (_lastRecordedDate == today)
        {
            // An event was already recorded today.
            return;
        }

        if (_lastRecordedDate == today.AddDays(-1))
        {
            // The activity was recorded yesterday.
            _currentStreak++;
        }
        else
        {
            // First activity or a broken streak.
            _currentStreak = 1;
        }

        _lastRecordedDate = today;
    }

    public string GetStreakData()
    {
        string date = _lastRecordedDate?.ToString("yyyy-MM-dd") ?? "";
        return $"{_currentStreak}|{date}";
    }

    public void RestoreStreak(int streak, DateTime? lastDate)
    {
        if (streak < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(streak));
        }

        _currentStreak = streak;
        _lastRecordedDate = lastDate;
    }
    public abstract string GetStringRepresentation();
}