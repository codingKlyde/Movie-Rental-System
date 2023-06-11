using System;
using System.Collections.Generic;
using System.Linq;


namespace Movie_Rental_System
{
    public class Program
    {
        private static string[] menuOption = { "Search" };                                          // Menu()
        private static string[] searchOption = { "Genre", "Price" };                                // Search()
        private static string[] genreOption = { "Action", "Comedy", "Horror", "War" };              // RentByGenre()
        private static string[] priceOption = { "PHP 200-1200", "PHP 1201-2200", "PHP 2201-" };     // RentByPrice()
        private static string[] againOption = { "Again", "Back", "Checkout" };                      // HandleRentAgainChoice()
        private static List<MovieInformation> rentedMovies = new List<MovieInformation>();          // Store all the rented movies in this list
        private static int totalCost = 0;
            

        // START
        static void Main(string[] args)
        { Menu(); }





        private static void Menu()
        {
            char menuChoice = MenuOption(menuOption);

            switch (menuChoice)
            {
                case '1': Search(); break;
                default: Console.WriteLine("\nPlease enter a valid choice.\n"); break;
            }
        }

        private static void Search()
        {
            char searchChoice = MenuOption(searchOption);

            switch (searchChoice)
            {
                case '1': RentByGenre(); break;
                case '2': RentByPrice(); break;
                default: Console.WriteLine("\nPlease enter a valid choice.\n"); break;
            }
        }

        private static void RentByGenre()
        {
            char genreChoice = MenuOption(genreOption);

            switch (genreChoice)
            {
                case '1': new ActionMovies().DisplayMovie(); break;
                case '2': new ComedyMovies().DisplayMovie(); break;
                case '3': new HorrorMovies().DisplayMovie(); break;
                case '4': new WarMovies().DisplayMovie(); break;
            }


            Console.Write("\nEnter movie title: ");
            string titleChoice = Console.ReadLine();

            IEnumerable<MovieInformation> byTitle_movies = null;

            switch (genreChoice)
            {
                case '1': byTitle_movies = new ActionMovies().GetActionMovies(); break;
                case '2': byTitle_movies = new ComedyMovies().GetComedyMovies(); break;
                case '3': byTitle_movies = new HorrorMovies().GetHorrorMovies(); break;
                case '4': byTitle_movies = new WarMovies().GetWarMovies(); break;
            }


            if (!string.IsNullOrWhiteSpace(titleChoice))
            {
                int cost = 0;
                bool movieTitle_exist = false;


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
                    totalCost += cost;

                    Console.WriteLine("\nMovie added to cart\n");

                    // Add the selected movie to the rentedMovies list
                    MovieInformation selectedMovie = byTitle_movies.FirstOrDefault(movie => movie.GetMovieTitle() == titleChoice);
                    rentedMovies.Add(selectedMovie);

                    HandleRentAgainChoice();
                }
                else
                {
                    Console.WriteLine("\nSorry, movie don't exist in the current genre.\n");
                    Search();
                }
            }
            else
            {
                Console.WriteLine("Please enter a correct movie title.");
                RentByGenre();
            }
        }

        private static void RentByPrice()
        {
            char priceChoice = MenuOption(priceOption);

            IEnumerable<MovieInformation> moviesInRange = null;
            IEnumerable<MovieInformation> allMovies = MovieInformation.GetAllMovies();          // Retrieve all movies

            switch (priceChoice)
            {
                case '1': moviesInRange = allMovies.Where(movie => movie.GetRentalPrice() >= 200 && movie.GetRentalPrice() <= 1200); break;
                case '2': moviesInRange = allMovies.Where(movie => movie.GetRentalPrice() >= 1201 && movie.GetRentalPrice() <= 2200); break;
                case '3': moviesInRange = allMovies.Where(movie => movie.GetRentalPrice() >= 2201); break;
            }


            // Display movies based on the selected price range
            Console.WriteLine(" ===========================================================");
            Console.WriteLine("            Movie            |     Year    |   Rent Price");
            Console.WriteLine(" -----------------------------------------------------------");
            foreach (MovieInformation movie in moviesInRange)
                Console.WriteLine($"       {movie.GetMovieTitle(),-22}|     {movie.GetMovieRelease(),-6}  |      {movie.GetRentalPrice()}");
            Console.WriteLine(" ===========================================================");


            Console.Write("\nEnter movie title: ");
            string titleChoice = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(titleChoice))  // Checks if input is null, empty, or consists only of whitespace characters
            {
                int cost = 0;
                bool movieTitle_exist = false;

                foreach (var movie in moviesInRange)
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
                    totalCost += cost;

                    Console.WriteLine("\nMovie added to cart\n");

                    // Add the selected movie to the rentedMovies list
                    MovieInformation selectedMovie = moviesInRange.FirstOrDefault(movie => movie.GetMovieTitle() == titleChoice);
                    rentedMovies.Add(selectedMovie);

                    HandleRentAgainChoice();
                }
                else
                {
                    Console.WriteLine("\nSorry, movie don't exist in the current genre.\n");
                    Search();
                }
            }
            else
            {
                Console.WriteLine("Please enter a correct movie title.");
                RentByGenre();
            }
        }

        public static void HandleRentAgainChoice()
        {
            char againChoice = MenuOption(againOption);

            switch (againChoice)
            {
                case '1': Search(); break;
                case '2': Menu(); break;
                case '3': Checkout(); break;
                default: Console.WriteLine("\nPlease enter a valid choice.\n"); break;
            }
        }

        public static void Checkout()
        {
            Console.WriteLine("===========================================\n");
            foreach (MovieInformation movie in rentedMovies)
                Console.WriteLine($"  {movie.GetMovieTitle(), -27}  PHP {movie.GetRentalPrice()}");
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"  TOTAL COST                   PHP {totalCost}");
            Console.WriteLine("===========================================");
        }

        private static char MenuOption(string[] displayOption)
        {
            char choice = ' '; 
            bool validChoice = false;


            while (!validChoice)
            {
                // Display menu options
                for (int i = 0; i < displayOption.Length; i++)
                    Console.WriteLine($"[{i + 1}] {displayOption[i]}");

                // Get input
                Console.Write("--\nINPUT: ");
                string menuChoice = Console.ReadLine();
                Console.WriteLine();

                // Checks if input is not more than one character
                // Checks if the input is not parsable to char
                if (menuChoice.Length != 1 || !char.TryParse(menuChoice, out choice))
                {
                    Console.WriteLine("\nPlease enter a valid numeric choice.\n"); 
                    continue;
                }
                // Checks if input is not greater or lesser than the range of options
                if (choice < '1' || choice > displayOption.Length.ToString()[0])
                {
                    Console.WriteLine("\nPlease enter a valid choice.\n"); 
                    continue;
                }
                validChoice = true;
            }


            return choice;
        }
    }
}