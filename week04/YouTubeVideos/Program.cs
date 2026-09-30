using System;

class Program
{
    static void Main(string[] args)
    {
        VideosData videosData = new VideosData();
        List<Video> videos = videosData.CreateVideos();

        int i = 1;

        Console.WriteLine("Welcome to the YouTube Videos Program!");
        Console.Write("Will you like to see the videos? (y/n): ");
        
        string response = Console.ReadLine();
        if (response.ToLower() == "y")
        {
            foreach (Video video in videos)
            {
                Console.WriteLine($"VIDEO {i}");
                i++;
                video.DisplayVideoInfo();
            }
        }
        Console.WriteLine("Thank you for using the YouTube Videos Program!");
    }
}