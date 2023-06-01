using System.Collections.Generic;


class HorrorMovies : MovieInformation
{
    public HorrorMovies(int movieNumber = 0, string movieName = "", int releaseYear = 0, int rentalCost = 0) 
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
        IEnumerable<HorrorMovies> horrorMovies = GetHorrorMovies();
        DisplayMovieInformation(horrorMovies);
    }

    // Insert action movies
    public IEnumerable<HorrorMovies> GetHorrorMovies()
    {
        return new List<HorrorMovies>
        {
            new HorrorMovies(190401, "Dawn of the Dead", 2004, 299),
            new HorrorMovies(190402, "#Alive", 2020, 1399),
            new HorrorMovies(190403, "The Divine Fury", 2019, 399),
            new HorrorMovies(190404, "Army of the Dead", 2021, 1399),
            new HorrorMovies(190405, "I Am Legend", 2007, 899)
        };
    }
}