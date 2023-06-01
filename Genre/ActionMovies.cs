using System.Collections.Generic;


class ActionMovies : MovieInformation
{
    public ActionMovies(int movieNumber = 0, string movieName = "", int releaseYear = 0, int rentalCost = 0)
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
        IEnumerable<ActionMovies> actionMovies = GetActionMovies();     
        DisplayMovieInformation(actionMovies);                         
    }

    // Insert action movies
    public IEnumerable<ActionMovies> GetActionMovies()
    {
        return new List<ActionMovies>
        {   
            new ActionMovies(190601, "Black Adam", 2022, 499),
            new ActionMovies(190602, "Kill Boksoon", 2023, 399),
            new ActionMovies(190603, "The Gray Man", 2022, 799),
            new ActionMovies(190604, "Ghosted", 2023, 499),
            new ActionMovies(190605, "65", 2023, 699)
        };
    }
}