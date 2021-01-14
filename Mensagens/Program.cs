using System;
using Mensagens.Entities;

namespace Mensagens
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment c1 = new Comment("Have a nice trip!");
            Comment c2 = new Comment("Wow thats awesome!");

            Post p1 = new Post(
                DateTime.Parse("21/06/2020 13:05:44"),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful country!",
                12
            );

            p1.AddComment(c1);
            p1.AddComment(c2);

            Comment c3 = new Comment("Good night!");
            Comment c4 = new Comment("May the Force be with you.");

            Post p2 = new Post(
                DateTime.Parse("28/06/2020 23:08:44"),
                "Good night guys!",
                "See yout tomorrow!",
                5
            );

            p2.AddComment(c3);
            p2.AddComment(c4);

            System.Console.WriteLine(p1);
            System.Console.WriteLine(p2);
        }
    }
}
