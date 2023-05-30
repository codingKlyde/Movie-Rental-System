using System;

class Horrorovies : MovieInformation
{
    // List of horror movies
    public static readonly Horrorovies[] horrormovies = new Horrorovies[]
    {
            new Horrorovies(190401, "Dawn of the Dead", 2004),
            new Horrorovies(190402, "#Alive", 2020),
            new Horrorovies(190403, "The Divine Fury", 2019),
            new Horrorovies(190404, "Army of the Dead", 2021),
            new Horrorovies(190405, "I Am Legend", 2007)
    };


    // Constructor
    public Horrorovies(int movieNumber = 0, string movieName = "", int releaseYear = 0) 
        : base(movieNumber, movieName, releaseYear)
    {
    }


    // Method
    public override void DisplayMovie()
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("    ID      |      Movie        |    Year   ");
        Console.WriteLine("---------------------------------------------");

        foreach (Horrorovies Hmovie in horrormovies)
            Console.WriteLine($"  {Hmovie.movieID.ToString().PadRight(10)}| {Hmovie.movieTitle,-18}|   {Hmovie.movieRelease}");

        Console.WriteLine("=============================================");
    }
}