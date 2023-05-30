using System;


namespace Movie_Rental_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] menu = { "[P]opular Movies", "[L]atest Movies", "[T]rending Movies", "[S]earch" };


            Console.WriteLine("\n=== REND-A-MOVIE  ===\n\n");
            

            foreach (string menuOption in menu)      
                Console.WriteLine(menuOption);
        

            Console.Write("\n>> ");
            char menuInput = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");


            switch (char.ToUpper(menuInput))
            {
                case 'P': PopularMovie(); break;
                case 'L': LatestMovie();  break;
                case 'T': TrendingMovie(); break;
                case 'S': SearchMovie(); break;
            }
            
        }





        private static void PopularMovie()
        { Console.WriteLine("POPULAR"); }

        private static void LatestMovie()
        { Console.WriteLine("LATEST"); }

        private static void TrendingMovie()
        { Console.WriteLine("TRENDING"); }

        private static void SearchMovie()
        {
            string[] genre = { "[A]ction", "A[N]imation", "[C]omedy", "[H]orror", "[S]ci-Fi", "[W]ar" };


            foreach (string genreOption in genre)
                Console.WriteLine(genreOption);

            Console.Write("\n>> ");
            char genreInput = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");

            switch (char.ToUpper(genreInput))
            {
                case 'A':
                    ActionMovies ActionM = new ActionMovies();
                    ActionM.DisplayMovie(); 
                    break;
                case 'N': Console.Write("ANIMATION!"); ; break;
                case 'C':
                    ComedyMovies ComedyM = new ComedyMovies();
                    ComedyM.DisplayMovie();
                    break;
                case 'H':
                    Horrorovies HorrorM = new Horrorovies();
                    HorrorM.DisplayMovie();
                    break;
                case 'S': Console.Write("SCI-FI!"); ; break;
                case 'W': Console.Write("WAR!"); break;
            }   
        }
    }
}