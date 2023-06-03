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
    public abstract int GetRentalPrice();
    public abstract void DisplayMovie();

    // Dispaly movies template
    protected void DisplayMovieInformation<T>(IEnumerable<T> movies)
    {
        Console.WriteLine(" ========================================================================");
        Console.WriteLine("            Movie            |     Year    |   Rent Price");
        Console.WriteLine(" ------------------------------------------------------------------------");
        foreach (T movie in movies)
        {
            dynamic movieGenre = movie;
            Console.WriteLine($"       {movieGenre.movieTitle,-25}|     {movieGenre.movieRelease,-6}  |      {movieGenre.rentalPrice}");
        }
        Console.WriteLine(" ========================================================================");
    }
}