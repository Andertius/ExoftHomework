namespace ServicesAndDI.Services
{
    public class PopcornService : IPopcornService
    {
        public string Buy(PopcornSize size)
        {
            return $"Bought a {size} popcorn";
        }
    }
}
