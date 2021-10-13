using Microsoft.AspNetCore.Mvc;

using ServicesAndDI.Services;

namespace ServicesAndDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movie)
        {
            _movieService = movie;
        }

        [HttpGet]
        public IActionResult Find(string name)
            => Ok(_movieService.GetMovie(name));
    }
}
