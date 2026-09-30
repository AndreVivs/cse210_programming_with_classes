using System;

class VideosData
{
    public List<Video> CreateVideos()
    {
        List<Video> videos = new List<Video>();

        Video cookingTogether = new Video(
            "Cooking Together",
            "Chefsito",
            1234
        );

        cookingTogether.AddComment(
            new Comment("Ana", "I loved this recipe!")
        );

        cookingTogether.AddComment(
            new Comment("Luis", "I am going to try this at home.")
        );

        cookingTogether.AddComment(
            new Comment("Maria", "This was really easy to follow.")
        );

        videos.Add(cookingTogether);


        Video grwmForToday = new Video(
            "GRWM for Today",
            "lulilu",
            1734
        );

        grwmForToday.AddComment(
            new Comment("Sofia", "I love your outfit!")
        );

        grwmForToday.AddComment(
            new Comment("Camila", "Where did you get that jacket?")
        );

        grwmForToday.AddComment(
            new Comment("Ethan", "I love your style!")
        );

        grwmForToday.AddComment(
            new Comment("Daniel", "Great video!")
        );

        videos.Add(grwmForToday);

        Video travelVlog = new Video(
            "Travel Vlog",
            "TravelerJohn",
            2045
        );

        travelVlog.AddComment(
            new Comment("Bob", "Great travel tips!")
        );

        travelVlog.AddComment(
            new Comment("Charlie", "I enjoyed the vlog!")
        );

        travelVlog.AddComment(
            new Comment("David", "I want to try this travel route!")
        );

        videos.Add(travelVlog);

        Video techReview = new Video(
            "Tech Review",
            "TechGuru",
            1500
        );

        techReview.AddComment(
            new Comment("John", "Very informative review!")
        );

        techReview.AddComment(
            new Comment("Jane", "I didn't know about this product.")
        );

        techReview.AddComment(
            new Comment("Alice", "I agree, very informative!")
        );

        videos.Add(techReview);

        return videos;
    }
}