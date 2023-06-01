using System.Collections.Generic;


class WarMovies : MovieInformation
{
    public WarMovies(int movieNumber = 0, string movieName = "", int releaseYear = 0, int rentalCost = 0)
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
        IEnumerable<WarMovies> warMovies = GetWarMovies();
        DisplayMovieInformation(warMovies);
    }

    // Insert action movies
    public IEnumerable<WarMovies> GetWarMovies()
    {
        return new List<WarMovies>
        {
            new WarMovies(190301, "Medieval", 2022, 1599),
            new WarMovies(190302, "Narvik", 2022, 399),
            new WarMovies(190303, "Shershaah", 2021, 199),
            new WarMovies(190304, "Greyhound", 2020, 399),
            new WarMovies(190305, "1917", 2019, 899)
        };
    }
}