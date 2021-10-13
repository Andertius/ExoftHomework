namespace ServicesAndDI.Services
{
    public interface IMovieService
    {
        Movie GetMovie(string name);
        bool BuyTicket(string name);
    }
}
