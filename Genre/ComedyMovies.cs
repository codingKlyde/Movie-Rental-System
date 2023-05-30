using System;

class ComedyMovies : MovieInformation
{
    // List of comedy movies
    public static readonly ComedyMovies[] comedymovies = new ComedyMovies[]
    {
            new ComedyMovies(190501, "Luck", 2022),
            new ComedyMovies(190502, "Senior Year", 2022),
            new ComedyMovies(190503, "The Bubble", 2022),
            new ComedyMovies(190504, "Army of Thieves", 2021),
            new ComedyMovies(190505, "Don't Look Up", 2021)
    };

    public ComedyMovies(int movieNumber = 0, string movieName = "", int releaseYear = 0) 
        : base(movieNumber, movieName, releaseYear)
    {
    }


    // Method
    public override void DisplayMovie()
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("    ID      |      Movie        |    Year   ");
        Console.WriteLine("---------------------------------------------");

        foreach (ComedyMovies Cmovie in comedymovies)
            Console.WriteLine($"  {Cmovie.movieID.ToString().PadRight(10)}| {Cmovie.movieTitle,-18}|   {Cmovie.movieRelease}");

        Console.WriteLine("=============================================");
    }
}