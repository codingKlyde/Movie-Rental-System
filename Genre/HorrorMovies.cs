using System.Collections.Generic;


public class HorrorMovies : MovieInformation
{
    // Constructor
    public HorrorMovies(string movieName = "", int releaseYear = 0, int rentalCost = 0)
        : base(movieName, releaseYear, rentalCost) { }


    // Method
    public override string GetMovieTitle() { return movieTitle; }
    public override int GetMovieRelease() { return movieRelease; }
    public override int GetRentalPrice() { return rentalPrice; }

    public override void DisplayMovie()
    {
        IEnumerable<HorrorMovies> horrorMovies = GetHorrorMovies();
        DisplayMovieInformation(horrorMovies);
    }


    // Insert horror movies
    public IEnumerable<HorrorMovies> GetHorrorMovies()
    {
        return new List<HorrorMovies>
        {
            new HorrorMovies("Dawn of the Dead", 2004, 299),
            new HorrorMovies("#Alive", 2020, 1399),
            new HorrorMovies("The Divine Fury", 2019, 399),
            new HorrorMovies("Army of the Dead", 2021, 1399),
            new HorrorMovies("I Am Legend", 2007, 899)
        };
    }
}