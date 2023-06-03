using System.Collections.Generic;


class ComedyMovies : MovieInformation
{
    // Constructor
    public ComedyMovies(string movieName = "", int releaseYear = 0, int rentalCost = 0)
        : base(movieName, releaseYear, rentalCost) { }


    // Method
    public override string GetMovieTitle() { return movieTitle; }
    public override int GetRentalPrice() { return rentalPrice; }

    public override void DisplayMovie()
    {
        IEnumerable<ComedyMovies> comedyMovies = GetComedyMovies();
        DisplayMovieInformation(comedyMovies);
    }

    // Insert comedy movies
    public IEnumerable<ComedyMovies> GetComedyMovies()
    {
        return new List<ComedyMovies>
        {
            new ComedyMovies("Luck", 2022, 899),
            new ComedyMovies("Senior Year", 2022, 799),
            new ComedyMovies("The Bubble", 2022, 599),
            new ComedyMovies("Army of Thieves", 2021, 1199),
            new ComedyMovies("Don't Look Up", 2021, 1299)
        };
    }
}