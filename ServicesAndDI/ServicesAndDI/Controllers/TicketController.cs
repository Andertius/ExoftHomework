using Microsoft.AspNetCore.Mvc;

using ServicesAndDI.Services;

namespace ServicesAndDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public IActionResult BuyTicket([FromQuery] string name, [FromServices] IMovieService service)
        {
            if (service.BuyTicket(name))
            {
                return Ok($"Bought a ticket for {name}");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
