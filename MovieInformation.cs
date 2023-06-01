using System.Collections.Generic;
using System;


public abstract  class MovieInformation
{
    // Property
    protected int movieID { get; }
    public string movieTitle { get; }
    public int movieRelease { get; }

    protected int rentalPrice { get; set; }


    // Constructor
    public MovieInformation(int movieNumber, string movieName, int releaseYear, int rentalCost)
    {
        movieID = movieNumber;
        movieTitle = movieName;
        movieRelease = releaseYear;

        rentalPrice = rentalCost;
    }


    // Method 
    public abstract int GetMovieID();
    public abstract int GetRentalPrice();





    public abstract void DisplayMovie();

    // Dispaly movies template
    protected void DisplayMovieInformation<T>(IEnumerable<T> movies)
    {
        Console.WriteLine(" ========================================================================");
        Console.WriteLine("     ID     |            Movie            |     Year    |   Rent Price");
        Console.WriteLine(" ------------------------------------------------------------------------");

        foreach (T movie in movies)
        {
            dynamic movieGenre = movie;
            Console.WriteLine($"   {movieGenre.movieID.ToString().PadRight(8)} |    {movieGenre.movieTitle,-25}|     {movieGenre.movieRelease,-6}  |      {movieGenre.rentalPrice}");
        }

        Console.WriteLine(" ========================================================================");
    }
}
