public abstract  class MovieInformation
{
    // Property
    public int movieID { get; }
    public string movieTitle { get;}
    public int movieRelease { get;}


    // Constructor
    public MovieInformation(int movieNumber, string movieName, int releaseYear)
    {
        movieID = movieNumber;
        movieTitle = movieName;
        movieRelease = releaseYear;
    }


    // Method 
    public abstract void DisplayMovie();
}
