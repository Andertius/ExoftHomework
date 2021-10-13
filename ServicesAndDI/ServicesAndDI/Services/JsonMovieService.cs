using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ServicesAndDI.Services
{
    public class JsonMovieService : IMovieService
    {
        public Movie GetMovie(string name)
        {
            string jsonString = File.ReadAllText("wwwroot/Movies.json");
            return JsonSerializer
                .Deserialize<IEnumerable<Movie>>(jsonString)
                .Where(x => x.Name == name)
                .FirstOrDefault();
        }

        public bool BuyTicket(string name)
        {
            string jsonString = File.ReadAllText("wwwroot/Movies.json");
            return JsonSerializer.Deserialize<IEnumerable<Movie>>(jsonString).Where(x => x.Name == name).Any();
        }
    }
}
