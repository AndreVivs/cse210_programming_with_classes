using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        List<EntryData> data = new List<EntryData>();

        foreach (Entry entry in _entries)
        {
            EntryData entryData = new EntryData();

            entryData.Date = entry.GetDate();
            entryData.PromptText = entry.GetPromptText();
            entryData.EntryText = entry.GetEntryText();

            data.Add(entryData);
        }

        string json = JsonSerializer.Serialize(
            data,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(fileName, json);
    }

    public void LoadFromFile(string fileName)
    {
        string json = File.ReadAllText(fileName);

        List<EntryData> data =
            JsonSerializer.Deserialize<List<EntryData>>(json);

        _entries.Clear();

        if (data != null)
        {
            foreach (EntryData entryData in data)
            {
                Entry entry = new Entry(
                    entryData.Date,
                    entryData.PromptText,
                    entryData.EntryText
                );

                _entries.Add(entry);
            }
        }
    }
}