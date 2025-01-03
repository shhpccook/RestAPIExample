using System;

namespace ConsoleFrameworkREST
{
    class Program
    {
        /*
         * I HAD TO DISCONNECT FROM VPN TO GET THIS TO RUN or you get unknown error 407 stuff
         */
        static void Main(string[] args)
        {
            Console.WriteLine("enter nasa key and press enter:\r\n");
            String apikey = Console.ReadLine();
            
            DateTime thisDate1 = DateTime.Today;
            String formatedDate = thisDate1.ToString("yyyy-MM-dd");
            NasaAPI nasa = new NasaAPI("https://api.nasa.gov/planetary/apod?api_key=" + apikey + "&date=" + formatedDate);
            nasa.Show();

            Console.WriteLine("*****************************************************************");

            PokemonAPI pokemon = new PokemonAPI("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=10");
            pokemon.Show();

            Console.WriteLine("*****************************************************************");

            pokemon.GetNext(false);
            pokemon.Show();

            //https://jsonplaceholder.typicode.com/comments
            //Note this is somewhat different as the root is not an object, but an array of objects.
            TypicodeAPI posts = new TypicodeAPI("https://jsonplaceholder.typicode.com/comments");
            //posts.Show();
            String post3String = posts.getPost(3).toString();
            Console.WriteLine("Post 3:\r\n" + post3String); 


            Console.ReadLine();
        }
    }
}
