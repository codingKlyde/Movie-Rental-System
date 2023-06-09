using System;
using System.Collections.Generic;
using System.Linq;


namespace Movie_Rental_System
{
    public class Program
    {
        private static List<MovieInformation> rentedMovies = new List<MovieInformation>();          // Store all the rented movies in this list
        private static int total = 0;


        // START
        static void Main(string[] args)
        {
            Console.WriteLine("===> RENT-A-MOVIE  <===\n\n");


            Menu();
        }





        private static void Menu()
        {
            string[] menuOption = { "[S]earch By" };


            // Display menu options and get input
            foreach (string menuDisplay in menuOption)
                Console.WriteLine(menuDisplay);
            Console.Write("--\nINPUT: ");
            char menuChoice = Convert.ToChar(Console.ReadLine());

            switch (char.ToUpper(menuChoice))
            {
                case 'S': SearchBy(); break;
            }
        }





        private static void SearchBy()
        {
            string[] searchOption = { "\n1. Genre", "2. Price" };
            int conv_searchChoice;


            // Display search options and get input
            foreach (var searchDisplay in searchOption)
                Console.WriteLine(searchDisplay);
            Console.Write("--\nINPUT: ");
            string searchChoice = Console.ReadLine();

            if (int.TryParse(searchChoice, out conv_searchChoice))
            {
                switch (conv_searchChoice)
                {
                    case 1: GenreSearch(); break;
                    case 2: PriceSearch(); break;
                }
            }
            else
                Console.WriteLine("\nPlease enter a valid choice.");
        }





        private static char GenreSearch()
        {
            string[] genreOption = { "\n[A]ction", "[C]omedy", "[H]orror", "[W]ar" };


            // Display genre options and get input
            foreach (string genreDisplay in genreOption)
                Console.WriteLine(genreDisplay);
            Console.Write("--\nINPUT: ");
            char genreChoice = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");

            // Determine which genre to be retrieved
            switch (char.ToUpper(genreChoice))
            {
                case 'A': new ActionMovies().DisplayMovie(); break;
                case 'C': new ComedyMovies().DisplayMovie(); break;
                case 'H': new HorrorMovies().DisplayMovie(); break;
                case 'W': new WarMovies().DisplayMovie(); break;
            }

            RentingProcess(genreChoice);


            return genreChoice;
        }





        private static char PriceSearch()
        {
            string[] priceOption = { "\n", "A. 200-1200", "B. 1201-2200", "C. 2201-" };


            // Display price options and get input
            foreach (string genreDisplay in priceOption)
                Console.WriteLine(genreDisplay);
            Console.Write("--\nINPUT: ");
            char priceChoice = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");

            IEnumerable<MovieInformation> moviesInRange = null;
            IEnumerable<MovieInformation> allMovies = MovieInformation.GetAllMovies();          // Retrieve all movies

            // Determine which price range to retrieve
            switch (char.ToUpper(priceChoice))
            {
                case 'A': moviesInRange = allMovies.Where(movie => movie.GetRentalPrice() >= 200 && movie.GetRentalPrice() <= 1200); break;
                case 'B': moviesInRange = allMovies.Where(movie => movie.GetRentalPrice() >= 1201 && movie.GetRentalPrice() <= 2200); break;
                case 'C': moviesInRange = allMovies.Where(movie => movie.GetRentalPrice() >= 2201); break;
            }


            Console.WriteLine(" ===========================================================");
            Console.WriteLine("            Movie            |     Year    |   Rent Price");
            Console.WriteLine(" -----------------------------------------------------------");
            foreach (MovieInformation movie in moviesInRange)
                Console.WriteLine($"       {movie.GetMovieTitle(), -25}|     {movie.GetMovieRelease(), -6}  |      {movie.GetRentalPrice()}");
            Console.WriteLine(" ===========================================================");


            return priceChoice;
        }





        private static void RentingProcess(char genreChoice) 
        {
            Console.Write("\nInsert the movie title you want to rent: ");
            string titleChoice = Console.ReadLine();    

            if (!string.IsNullOrWhiteSpace(titleChoice))  // Checks if input is null, empty, or consists only of whitespace characters
            {
                bool movieTitle_exist = false;
                int cost = 0;
                IEnumerable<MovieInformation> byTitle_movies = null;
                 

                switch (char.ToUpper(genreChoice))
                {
                    case 'A': byTitle_movies = new ActionMovies().GetActionMovies(); break;
                    case 'C': byTitle_movies = new ComedyMovies().GetComedyMovies(); break;
                    case 'H': byTitle_movies = new HorrorMovies().GetHorrorMovies(); break;
                    case 'W': byTitle_movies = new WarMovies().GetWarMovies(); break;
                }


                foreach (var movie in byTitle_movies)
                {
                    if (movie.GetMovieTitle() == titleChoice)
                    {
                        movieTitle_exist = true;
                        cost = movie.GetRentalPrice();
                        break;
                    }
                }


                if (movieTitle_exist)
                {
                    string[] againOption = { "[A]gain", "[B]ack", "[C]heckout" };


                    total += cost;                                                
                    Console.WriteLine("\nMovie added to cart\n");

                    // Add the selected movie to the rentedMovies list
                    MovieInformation selectedMovie = byTitle_movies.FirstOrDefault(movie => movie.GetMovieTitle() == titleChoice);
                    rentedMovies.Add(selectedMovie);

                    // Display choice to rent again and get input
                    foreach (string againDisplay in againOption)
                        Console.WriteLine(againDisplay);
                    Console.Write("--\nINPUT: ");
                    char againChoice = Convert.ToChar(Console.ReadLine());

                    switch (char.ToUpper(againChoice))
                    {
                        case 'A': RentingProcess(genreChoice); break;
                        case 'B': SearchBy(); break;
                        case 'C': Checkout(); break;
                    }
                }
                else
                {
                    Console.WriteLine("\nSorry, the movie doesn't exist in the current genre.\n");
                }
            }
            else
            {
                Console.WriteLine("Please enter a correct movie ID.");
            }
            Console.WriteLine();
        }





        private static void Checkout()
        {
            Console.WriteLine("\n======================================");
            foreach (MovieInformation movie in rentedMovies)
                Console.WriteLine($"  {movie.GetMovieTitle(), -20} ................ PHP {movie.GetRentalPrice()}");

            Console.WriteLine($"\n  TOTAL:                                PHP {total}");
            Console.WriteLine("======================================");
        }
    }
}