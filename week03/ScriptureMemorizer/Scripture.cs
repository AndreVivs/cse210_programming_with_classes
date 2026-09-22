using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<List<Word>> _paragraphs;
    private Random _random = new Random();

    public Scripture(Reference reference, List<string> paragraphs)
    {
        _reference = reference;
        _paragraphs = new List<List<Word>>();

        foreach (string paragraph in paragraphs)
        {
            List<Word> words = new List<Word>();

            string[] textWords = paragraph.Split(" ");

            foreach (string textWord in textWords)
            {
                words.Add(new Word(textWord));
            }

            _paragraphs.Add(words);
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine();

        foreach (List<Word> paragraph in _paragraphs)
        {
            foreach (Word word in paragraph)
            {
                Console.Write(word.GetDisplayText() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();

        foreach (List<Word> paragraph in _paragraphs)
        {
            foreach (Word word in paragraph)
            {
                if (!word.IsHidden())
                {
                    visibleWords.Add(word);
                }
            }
        }

        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);

            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (List<Word> paragraph in _paragraphs)
        {
            foreach (Word word in paragraph)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
        }

        return true;
    }
}