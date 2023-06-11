using System.Collections.Generic;


public class ActionMovies : MovieInformation
{
    // Constructor
    public ActionMovies(string movieName = "", int releaseYear = 0, int rentalCost = 0)
        : base(movieName, releaseYear, rentalCost) { }


    // Method
    public override string GetMovieTitle() { return movieTitle; }
    public override int GetMovieRelease() { return movieRelease; }
    public override int GetRentalPrice() { return rentalPrice; }

    public override void DisplayMovie()
    {
        IEnumerable<ActionMovies> actionMovies = GetActionMovies();
        DisplayMovieInformation(actionMovies);
    }

    // Insert action movies
    public IEnumerable<ActionMovies> GetActionMovies()
    {
        return new List<ActionMovies>
        {
            new ActionMovies("Black Adam", 2022, 499),
            new ActionMovies("Kill Boksoon", 2023, 399),
            new ActionMovies("The Gray Man", 2022, 3399),
            new ActionMovies("Ghosted", 2023, 499),
            new ActionMovies("65", 2023, 699)
        };
    }
}