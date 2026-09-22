using System;
using System.Collections.Generic;

public class ScriptureGenerator
{
    private List<Scripture> _scriptures;
    private Random _random;


    public ScriptureGenerator()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();

        Reference johnReference =
            new Reference("John", 3, 16);

        Scripture john = new Scripture(
            johnReference,
            new List<string>
            {
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            }
        );

        _scriptures.Add(john);


        Reference philippiansReference =
            new Reference("Philippians", 4, 13);

        Scripture philippians = new Scripture(
            philippiansReference,
            new List<string>
            {
                "I can do all this through him who gives me strength."
            }
        );

        _scriptures.Add(philippians);


        Reference proverbsReference =
            new Reference("Proverbs", 3, 5, 6);

        Scripture proverbs = new Scripture(
            proverbsReference,
            new List<string>
            {
                "Trust in the Lord with all your heart and lean not on your own understanding.",
                "In all your ways submit to him, and he will make your paths straight."
            }
        );

        _scriptures.Add(proverbs);
    }

    public Scripture GenerateScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}