using System.Collections.Generic;
using System;


public abstract class MovieInformation
{
    // Property
    protected string movieTitle { get; }
    public int movieRelease { get; }
    protected int rentalPrice { get; set; }


    // Constructor
    public MovieInformation(string movieName, int releaseYear, int rentalCost)
    {
        movieTitle = movieName;
        movieRelease = releaseYear;
        rentalPrice = rentalCost;
    }


    // Method 
    public abstract string GetMovieTitle();
    public abstract int GetMovieRelease();
    public abstract int GetRentalPrice();
    public abstract void DisplayMovie();


    // Adds all the movies from each genre class 
    public static IEnumerable<MovieInformation> GetAllMovies()
    {
        List<MovieInformation> allMovies = new List<MovieInformation>();

        allMovies.AddRange(new ActionMovies().GetActionMovies());
        allMovies.AddRange(new ComedyMovies().GetComedyMovies());
        allMovies.AddRange(new HorrorMovies().GetHorrorMovies());
        allMovies.AddRange(new WarMovies().GetWarMovies());


        return allMovies;
    }


    // Dispaly movies template for genres
    protected void DisplayMovieInformation<T>(IEnumerable<T> movies)
    {
        Console.WriteLine(" ===========================================================");
        Console.WriteLine("            Movie            |     Year    |   Rent Price");
        Console.WriteLine(" -----------------------------------------------------------");
        foreach (T movie in movies)
        {
            dynamic movieGenre = movie;
            Console.WriteLine($"        {movieGenre.movieTitle, -21}|     {movieGenre.movieRelease, -6}  |      {movieGenre.rentalPrice}");
        }
        Console.WriteLine(" ===========================================================");
    }
}