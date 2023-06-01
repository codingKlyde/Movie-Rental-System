using System.Collections.Generic;


class ComedyMovies : MovieInformation
{
    public ComedyMovies(int movieNumber = 0, string movieName = "", int releaseYear = 0, int rentalCost = 0)
        : base(movieNumber, movieName, releaseYear, rentalCost) {}


    // Method
    public override int GetMovieID()
    {
        return movieID;
    }

    public override int GetRentalPrice()
    {
        return rentalPrice;
    }

    public override void DisplayMovie()
    {
        IEnumerable<ComedyMovies> comedyMovies = GetComedyMovies();
        DisplayMovieInformation(comedyMovies);
    }

    // Insert action movies
    public IEnumerable<ComedyMovies> GetComedyMovies()
    {
        return new List<ComedyMovies>
        {
            new ComedyMovies(190501, "Luck", 2022, 899),
            new ComedyMovies(190502, "Senior Year", 2022, 799),
            new ComedyMovies(190503, "The Bubble", 2022, 599),
            new ComedyMovies(190504, "Army of Thieves", 2021, 1199),
            new ComedyMovies(190505, "Don't Look Up", 2021, 1299)
        };
    }
}