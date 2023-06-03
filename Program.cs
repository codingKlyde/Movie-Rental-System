using System;
using System.Collections.Generic;


namespace Movie_Rental_System
{
    public class Program
    {
        private static int total = 0;


        // START
        static void Main(string[] args)
        {
            Console.WriteLine("=== REND-A-MOVIE  ===\n\n");


            MainMenu();
        }





        private static void MainMenu()
        {
            string[] menu = { "[P]opular Movies", "[L]atest Movies", "[S]earch" };


            // Display main menu and get input
            foreach (string menuOption in menu)
                Console.WriteLine(menuOption);
            Console.Write(">> ");
            char menuInput = Convert.ToChar(Console.ReadLine());

            switch (char.ToUpper(menuInput))
            {
                case 'P': PopularMovies(); break;
                case 'L': LatestMovies(); break;
                case 'S': Search(); break;
            }
        }





        private static void PopularMovies()
        { Console.WriteLine("POPULAR"); }





        private static void LatestMovies()
        { Console.WriteLine("LATEST"); }





        private static void Search()
        {
            string[] searchOptions = { "\n1. Genre", "2. Year" };
            int number;


            // Display search options and get input
            foreach (var displayOptions in searchOptions)
                Console.WriteLine(displayOptions);
            Console.Write(">> ");
            string searchInput = Console.ReadLine();

            if (int.TryParse(searchInput, out number))
            {
                switch (number)
                {
                    case 1: GenreSearch(); break;
                    case 2: YearSearch(); break;
                }
            }
            else
                Console.WriteLine("\nInvalid input. Please enter a choice.");
        }



        private static char GenreSearch()
        {
            string[] genre = { "\n[A]ction", "[C]omedy", "[H]orror", "[W]ar" };


            // Display genre menu and get input
            foreach (string genreOption in genre)
                Console.WriteLine(genreOption);
            Console.Write(">> ");
            char genreInput = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");

            switch (char.ToUpper(genreInput))
            {
                case 'A': new ActionMovies().DisplayMovie(); break;
                case 'C': new ComedyMovies().DisplayMovie(); break;
                case 'H': new HorrorMovies().DisplayMovie(); break;
                case 'W': new WarMovies().DisplayMovie(); break;
            }

            RentMovie(genreInput);


            return genreInput;
        }





        private static void YearSearch()
        { Console.WriteLine(); }





        private static void RentMovie(char genreInput)
        {
            Console.WriteLine("\nInsert the movie ID you want to rent:");
            Console.Write(">> ");
            string rentInput = Console.ReadLine();

            if (rentInput != null)
            {
                bool movieExists = false;
                int cost = 0;
                IEnumerable<MovieInformation> movies = null;


                switch (char.ToUpper(genreInput))
                {
                    case 'A': movies = new ActionMovies().GetActionMovies(); break;
                    case 'C': movies = new ComedyMovies().GetComedyMovies(); break;
                    case 'H': movies = new HorrorMovies().GetHorrorMovies(); break;
                    case 'W': movies = new WarMovies().GetWarMovies(); break;
                }


                foreach (var movie in movies)
                {
                    if (movie.GetMovieTitle() == rentInput)
                    {
                        movieExists = true;
                        cost = movie.GetRentalPrice();
                        break;
                    }
                }


                if (movieExists)
                {
                    string[] again = { "[A]gain", "[B]ack", "[C]heckout" };


                    total += cost;                                                
                    Console.WriteLine("\nTotal cost: {0}\n", total);

                    foreach (string againOption in again)
                        Console.WriteLine(againOption);
                    Console.Write(">> ");
                    char againInput = Convert.ToChar(Console.ReadLine());

                    switch (char.ToUpper(againInput))
                    {
                        case 'A': RentMovie(genreInput); break;
                        case 'B': Search(); break;
                        case 'C':
                            Console.WriteLine("\nTotal cost is {0}. Thanks for renting! :)", total);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nSorry, the movie doesn't exist in the current genre\n");
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine("Please enter a correct movie ID");
                RentMovie(genreInput);
            }
            Console.WriteLine();
        }
    }
}