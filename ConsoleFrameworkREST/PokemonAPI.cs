using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleFrameworkREST
{
    class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    class Pokedex
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public IList<Pokemon> results { get; set; }

    }

    class PokemonAPI:BaseAPI
    {
        public PokemonAPI(String URI)
        {
            this.URI = URI;
            base.RunAsync().GetAwaiter().GetResult();
        }

        override public void Show()
        {
            Pokedex dex = (Pokedex)result;
            if (dex==null || dex.results == null) return;
            Console.WriteLine($"There are {dex.count} in the Pokemon Universe!");
            
            foreach (Pokemon pokemon in dex.results)
            {
                Console.WriteLine($"Name: {pokemon.name}\r\n url: {pokemon.url}");

            }
        }

        override public void Convert(String data)
        {
            this.result = JsonConvert.DeserializeObject<Pokedex>(data);
        }

        private void refresh(Boolean ConcatData)
        {
            //Get information about to be overwritten
            Pokedex oldDex = ((Pokedex)result);
            IList<Pokemon> oldlist = oldDex.results;

            //get new info
            base.RunAsync().GetAwaiter().GetResult();
            this.Convert(this.data);

            //concat data if required
            if (!ConcatData) return;
            Pokedex newDex = ((Pokedex)result);
            foreach (Pokemon mon in oldlist)
            {
                newDex.results.Add(mon);
            }
        }

        public void GetPrevious(Boolean ConcatData)
        {
            if (result == null) return;
            this.URI = ((Pokedex)result).previous;
            this.refresh(ConcatData);
        }

        public void GetNext(Boolean ConcatData)
        {
            if (result == null) return;
            this.URI = ((Pokedex)result).next;
            this.refresh(ConcatData);
        }
    }
}
