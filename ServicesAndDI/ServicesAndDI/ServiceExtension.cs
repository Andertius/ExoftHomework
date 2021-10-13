using Microsoft.Extensions.DependencyInjection;

using ServicesAndDI.Services;

namespace ServicesAndDI
{
    public static class ServiceExtension
    {
        public static void AddMovieServices(this IServiceCollection isc)
        {
            isc.AddScoped<IMovieService, JsonMovieService>();
        }            
    }
}
