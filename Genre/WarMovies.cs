using System.Collections.Generic;


public class WarMovies : MovieInformation
{
    // Constructor
    public WarMovies(string movieName = "", int releaseYear = 0, int rentalCost = 0)
        : base(movieName, releaseYear, rentalCost) { }


    // Method
    public override string GetMovieTitle() { return movieTitle; }
    public override int GetMovieRelease() { return movieRelease; }
    public override int GetRentalPrice() { return rentalPrice; }

    public override void DisplayMovie()
    {
        IEnumerable<WarMovies> warMovies = GetWarMovies();
        DisplayMovieInformation(warMovies);
    }


    // Insert war movies
    public IEnumerable<WarMovies> GetWarMovies()
    {
        return new List<WarMovies>
        {
            new WarMovies("Medieval", 2022, 1599),
            new WarMovies("Narvik", 2022, 399),
            new WarMovies("Shershaah", 2021, 199),
            new WarMovies("Greyhound", 2020, 399),
            new WarMovies("1917", 2019, 899)
        };
    }
}