using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Start Programming", "Code Academy", 420);
        video1.AddComment(new Comment("James", "This video helped me understand programming better."));
        video1.AddComment(new Comment("Maria", "Great explanation and very clear examples."));
        video1.AddComment(new Comment("David", "I am just starting, and this was very useful."));

        Video video2 = new Video("Top 10 Soccer Skills", "Football World", 350);
        video2.AddComment(new Comment("Carlos", "These skills are amazing!"));
        video2.AddComment(new Comment("Samuel", "I want to practice these moves this weekend."));
        video2.AddComment(new Comment("Ana", "The third skill was my favorite."));

        Video video3 = new Video("Best Places to Visit in Mozambique", "Travel Life", 600);
        video3.AddComment(new Comment("Osvaldo", "Mozambique has so many beautiful places."));
        video3.AddComment(new Comment("Kevin", "I would love to visit the beaches there."));
        video3.AddComment(new Comment("Grace", "The video quality is really good."));

        Video video4 = new Video("Simple Chicken Recipe", "Home Cooking", 480);
        video4.AddComment(new Comment("Emily", "I tried this recipe and it was delicious."));
        video4.AddComment(new Comment("John", "Very easy to follow."));
        video4.AddComment(new Comment("Lisa", "Please make more cooking videos."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}