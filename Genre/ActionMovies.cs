using System;

class ActionMovies : MovieInformation
{
    // List of action movies
    public static readonly ActionMovies[] actionmovies = new ActionMovies[]
    {
            new ActionMovies(190601, "Black Adam", 2022),
            new ActionMovies(190602, "Kill Boksoon", 2023),
            new ActionMovies(190603, "The Gray Man", 2022),
            new ActionMovies(190604, "Ghosted", 2023),
            new ActionMovies(190605, "65", 2023)
    };


    // Constructor
    public ActionMovies(int movieNumber = 0, string movieName = "", int releaseYear = 0)
        : base(movieNumber, movieName, releaseYear)
    {
    }


    // Method
    public override void DisplayMovie()
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("     ID     |      Movie        |    Year   ");
        Console.WriteLine("---------------------------------------------");

        foreach (ActionMovies Amovie in actionmovies)
            Console.WriteLine($"  {Amovie.movieID.ToString().PadRight(10)}| {Amovie.movieTitle,-18}|   {Amovie.movieRelease}");

        Console.WriteLine("=============================================");
    }
}