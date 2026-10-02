using System;

class WrittingAssignment : Assignment
{
    private string _title;

    public WrittingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        string topic = GetTopic();
        return $"{studentName} - {topic} - {_title} by {studentName}";
    }
}